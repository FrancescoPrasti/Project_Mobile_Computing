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

    //private bool startPos = false;

    public Vector3 posIniziale;
    public Vector3 posAttuale;

    public static Vector3 lastCheckPointPos = new Vector3(-12.4f, -3.760416f, 0);
    //public bool primoCaricamento;

    //public CaricamentiScenaSampleScene carSample;
    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player;
        player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        /*primoCaricamento = carSample.primoCaricamento;
        if(primoCaricamento == true)
        {
            Debug.Log("Entrato nel primo");
            player = Instantiate(playerPrefabs[characterIndex], posIniziale, Quaternion.identity);
            carSample.primoCaricamento = false;
        }
        else
        {
            Debug.Log("Entrato nel secondo");
            player = Instantiate(playerPrefabs[characterIndex], posAttuale, Quaternion.identity);
            //carSample.primoCaricamento = true;
        }*/
        /*if (startPos == false)
        {
            player = Instantiate(playerPrefabs[characterIndex], new Vector3(-12.04f, -3.82f, 0), Quaternion.identity);
            startPos = true;
        }
        else
            player = Instantiate(playerPrefabs[characterIndex], posIniziale, Quaternion.identity);*/
        VCam.m_Follow = player.transform;

        //CoinNumber = PlayerPrefs.GetInt("CoinNumber", 0);  // se non esiste la variabile CoinNumber la crea e la inizializza a zero
        isGameOver = false;
        //playFabManager.getVirtualCurrencies();
        //CoinNumber = 0;
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
