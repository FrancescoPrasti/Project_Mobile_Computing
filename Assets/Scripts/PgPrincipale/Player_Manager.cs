using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static int CoinNumber;
    public TextMeshProUGUI CoinText;

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
        GameObject player = Instantiate(playerPrefabs[characterIndex], posIniziale, Quaternion.identity);
        VCam.m_Follow = player.transform;

        CoinNumber = PlayerPrefs.GetInt("CoinNumber", 0);  // se non esiste la variabile CoinNumber la crea e la inizializza a zero
        isGameOver = false;
        //CoinNumber = 0;
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
