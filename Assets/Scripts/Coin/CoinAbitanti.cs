using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinAbitanti : MonoBehaviour
{
    private Rigidbody2D itemRb;
    public float dropForce = 5;
    Transform target;
    void Start()
    {
        /*target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());*/
        itemRb = GetComponent<Rigidbody2D>();
        itemRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
        //itemRb.position = new Vector2(itemRb.position.x, -3.92f);
    }

    void FixedUpdate()
    {
        if(itemRb != null && itemRb.position.y <= -3.92f)
            Destroy(itemRb.GetComponent<Rigidbody2D>());
    }

    private void OnColliderEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerManager.CoinNumber++;
            Destroy(gameObject);
        }
    }
}
