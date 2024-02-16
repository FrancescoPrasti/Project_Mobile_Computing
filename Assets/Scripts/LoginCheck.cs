using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginCheck : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelsMenu;
    public GameObject loginPanel;
    public GameObject ShopButton;
    public GameObject LeaderboardButton;

    void FixedUpdate()
    {
        if (PlayFabManager.isLogged)
        {
            ShopButton.SetActive(true);
            LeaderboardButton.SetActive(true);
        }
        else
        {
            ShopButton.SetActive(false);
            LeaderboardButton.SetActive(false);
        }
    }

    public void check()
    {
        if (PlayFabManager.isLogged)
        {
            mainMenu.SetActive(false);
            levelsMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(false);
            loginPanel.SetActive(true);
        }
    }
}
