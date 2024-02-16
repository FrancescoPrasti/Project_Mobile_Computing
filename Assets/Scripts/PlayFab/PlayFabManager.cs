using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;

public class PlayFabManager : MonoBehaviour
{

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

    private void Start()
    {
   
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
        /*var request2 = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = usernameField.text,
        };*/
        PlayFabClientAPI.RegisterPlayFabUser(request1, OnRegisterSuccess, OnError);
        //PlayFabClientAPI.UpdateUserTitleDisplayName(request2, OnDisplayNameUpdate, OnError);
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

}
