using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int CoinNumber;
    public TextMeshProUGUI CoinText;

    void Start()
    {

    }


    void FixedUpdate()
    {
        CoinText.text = CoinNumber.ToString();
    }
}
