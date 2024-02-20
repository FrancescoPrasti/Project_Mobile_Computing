using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab.ClientModels;
using PlayFab;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;
    public Character[] characters;

    public Button unlockButton;
    public TextMeshProUGUI coinText;

    public void UpdateShop()
    {

        PlayFabManager.instance.GetCharacters();

        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in skins)
            player.SetActive(false);

        skins[selectedCharacter].SetActive(true);

        /*foreach (Character c in characters)
        {
            //if (c.price == 0)
                c.isUnlocked = true;
            else
            {
                if(PlayerPrefs.GetInt(c.name, 0) == 0)
                {
                    c.isUnlocked = false;
                }
                else
                {
                    c.isUnlocked = true;
                }
                // Stessa cosa si pu� scrivere cosi' in maniera meno verbosa
                c.isUnlocked = false;PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }*/
        UpdateUI();
    }

    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;
        skins[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        UpdateUI();
    }

    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
            selectedCharacter = skins.Length - 1;
        skins[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log(PlayerManager.CoinNumber);
        coinText.text = PlayerManager.CoinNumber.ToString();
        Debug.Log(PlayerManager.CoinNumber);
        Debug.Log(characters[selectedCharacter].isUnlocked);

        if (characters[selectedCharacter].isUnlocked == true)
        {
            Debug.Log("DENTRO IF");
            unlockButton.gameObject.SetActive(false);
        }

        else
        {
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price:" + characters[selectedCharacter].price;
            if (PlayerManager.CoinNumber < characters[selectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }

    public void BuyItem(int price)
    {
        AudioManager.instance.Play("Buy");
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = "CN",
            Amount = price
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);
        PlayerManager.CoinNumber -= price;
    }

    void OnSubtractCoinsSuccess(ModifyUserVirtualCurrencyResult result)
    {
        PlayFabManager.instance.SaveShop();
    }

    public void Unlock()
    {
        int coins = PlayerPrefs.GetInt("CoinNumber", 0);
        int price = characters[selectedCharacter].price;
        //PlayerPrefs.SetInt("CoinNumber", coins - price);
        this.BuyItem(price);
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        characters[selectedCharacter].isUnlocked = true;
        UpdateUI();
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error: " + error.ErrorMessage);
    }

}
