using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinAbitanti : MonoBehaviour
{

    private Rigidbody2D itemRb;
    public float dropForce = 5;
    void Start()
    {
        itemRb = GetComponent<Rigidbody2D>();
        itemRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }

    /*void FixedUpdate()
    {
        if(itemRb != null && itemRb.position.y <= -3.92f)
            Destroy(itemRb.GetComponent<Rigidbody2D>());
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            /*PlayerManager.CoinNumber++;
            PlayerPrefs.SetInt("CoinNumber", PlayerManager.CoinNumber);*/
            PlayFabManager.instance.AddVirtualCurrency();
            Destroy(gameObject);
        }
        else if(collision.tag == "Terreno")
            Destroy(itemRb.GetComponent<Rigidbody2D>());
    }
}
