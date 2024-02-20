using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int CoinNumber;
    public TextMeshProUGUI CoinText;

    public static int Score;
    public static bool isGameOver;
    public GameObject GameOverScreen;
    public GameObject pauseMenuScreen;
    public Button pauseButton;

    public AudioManager audio;
    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;

    public Vector3 posIniziale;
    public Vector3 posAttuale;

    public static Vector3 lastCheckPointPos = new Vector3(-12.4f, -3.760416f, 0);


  
    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player;
        player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        
        VCam.m_Follow = player.transform;

        isGameOver = false;
        
        Score = 0;
    }

    void FixedUpdate()
    {
        if (isGameOver)
        {
            audio.GetComponent<GestioneAudio>().FermaAudio();
            audio.GetComponent<GestioneAudio>().SoundGameOver();
            pauseButton.interactable = false;
            GameOverScreen.SetActive(true);
            PlayFabManager.instance.SendLeaderboard(Score);
            Time.timeScale = 0;
        }
        CoinText.text = CoinNumber.ToString();
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HealthManager.cuoriColorati = 3;
        ManaManager.manaColorati = 3;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
        //gest.PausaAudio();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
        //gest.RipresaAudio();
    }

    public void GoToMenu()
    {
        //gest.FermaAudio();
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

}
