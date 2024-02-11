using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerManager : MonoBehaviour
{
    public static int CoinNumber;
    public TextMeshProUGUI CoinText;

    public PlayFabManager playFabManager;
    public static int Score;

    public static bool isGameOver;
    public GameObject GameOverScreen;
    public GameObject pauseMenuScreen;

    private void Awake()
    {
        isGameOver = false;
        CoinNumber = 0;
        Score = 0;
    }

    void Start()
    {
        AudioManager.instance.Play("VillageMusic");
    }


    void FixedUpdate()
    {
        if (isGameOver)
        {
            GameOverScreen.SetActive(true);
            playFabManager.SendLeaderboard(Score);
            Time.timeScale = 0;
        }
        CoinText.text = CoinNumber.ToString();
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        AudioManager.instance.Stop("VillageMusic");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

}
