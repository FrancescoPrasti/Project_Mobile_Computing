using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int CoinNumber;
    public TextMeshProUGUI CoinText;
    public static bool isGameOver;
    public GameObject GameOverScreen;
    private void Awake()
    {
        isGameOver = false;
    }

    void Start()
    {

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
}
