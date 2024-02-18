using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            /*PlayerManager.CoinNumber++;
            PlayerPrefs.SetInt("CoinNumber", PlayerManager.CoinNumber);*/
            PlayFabManager.instance.AddVirtualCurrency();
            Destroy(gameObject);
        }
    }
}
