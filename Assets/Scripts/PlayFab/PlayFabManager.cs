using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;

public class PlayFabManager : MonoBehaviour
{

    public static PlayFabManager instance;

    [Header("UI")]
    public Text messageLoginText;
    public Text messageRegistrationText;
    public InputField usernameField;
    public InputField emailLoginInput;
    public InputField passwordLoginInput;
    public InputField emailRegistrationInput;
    public InputField passwordRegistrationInput;
    public GameObject levelsMenu;
    public GameObject loginPanel;

    public static bool isLogged = false;

    public GameObject rowPrefab;
    public Transform rowsParent;
    public CharacterSelect characterSelect;

    private void Awake()
    {
        instance = this;
    }

    public void RegisterButton()
    {
        if (passwordRegistrationInput.text.Length < 6)
        {
            messageRegistrationText.text = "Password too short ";
            return;
        }
        var request1 = new RegisterPlayFabUserRequest
        {
            Email = emailRegistrationInput.text,
            Password = passwordRegistrationInput.text,
            DisplayName = usernameField.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request1, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageRegistrationText.text = "Registered and logged in";
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name!");
    }

    public void LoginButton()
    {
        var request= new LoginWithEmailAddressRequest { 
            Email = emailLoginInput.text,
            Password = passwordLoginInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);


    }

    void OnLoginSuccess(LoginResult result)
    {
        isLogged = true;
        messageLoginText.text = "Logged in!";
        Debug.Log("Successful login!");
        levelsMenu.SetActive(true);
        loginPanel.SetActive(false);
        this.getVirtualCurrencies();
        characterSelect.UpdateShop();

    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailLoginInput.text,
            TitleId = "E218D"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);

    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageLoginText.text = "Password reset mail sent";

    }

    void OnError(PlayFabError error)
    {
        messageLoginText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "ScorePoints",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardSent, OnError);
    }

    void OnLeaderboardSent(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leaderboard Successfully sent");
    }

    public void getLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "ScorePoints",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            //Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }

    public void getVirtualCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }

    void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
        PlayerManager.CoinNumber = result.VirtualCurrency["CN"];
    }

    public void AddVirtualCurrency()
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = "CN",
            Amount = 1
        };
        PlayerManager.CoinNumber++;
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnAddVirtualCurrencySuccess, OnError);
    }

    void OnAddVirtualCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Coin added!");
    }


    public void SaveShop()
    {
        List<Character> c = new List<Character>();
        foreach(var item in characterSelect.characters)
        {
            
            c.Add(item);
           
        }

        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"CharactersUnlocked", JsonConvert.SerializeObject(c)}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {

    }


    public void GetCharacters()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnCharactersDataRecieved, OnError);
    }

    void OnCharactersDataRecieved(GetUserDataResult result)
    {
        if(result.Data!=null && result.Data.ContainsKey("CharactersUnlocked"))
        {
            characterSelect.characters = JsonConvert.DeserializeObject<Character[]>(result.Data["CharactersUnlocked"].Value);

        }
        else
        {
            Character[] c = new Character[] {new Character("Fire Warrior",0,true), new Character("Wizard", 5, false) };
            characterSelect.characters = c;
        }
    }
}
