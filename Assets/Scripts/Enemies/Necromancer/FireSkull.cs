using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkull : MonoBehaviour
{
    GameObject target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!target.GetComponent<PlayerCollision>().isInvincible)
            {
                target.GetComponent<PlayerCollision>().TakeDamage();
                Destroy(gameObject);
            }
        }
    }
}
