using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
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

    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;

    

    public new Vector3 posIniziale;
    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player;
        player = Instantiate(playerPrefabs[characterIndex], posIniziale, Quaternion.identity);
        /*if (startPos == false)
        {
            player = Instantiate(playerPrefabs[characterIndex], new Vector3(-12.04f, -3.82f, 0), Quaternion.identity);
            startPos = true;
        }
        else
            player = Instantiate(playerPrefabs[characterIndex], posIniziale, Quaternion.identity);*/
        VCam.m_Follow = player.transform;

        CoinNumber = PlayerPrefs.GetInt("CoinNumber", 0);  // se non esiste la variabile CoinNumber la crea e la inizializza a zero
        isGameOver = false;
        //CoinNumber = 0;
        Score = 0;
    }

    void Start()
    {
        //AudioManager.instance.Play("VillageMusic");
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
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);
        HealthManager.cuoriColorati = 3;
        ManaManager.manaColorati = 3;
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
       
        //AudioManager.instance.Stop("VillageMusic");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

}
