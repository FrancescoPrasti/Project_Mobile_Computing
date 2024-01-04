using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
             Destroy(collision.gameObject);
             Destroy(gameObject);
        }
        if(collision.tag == "Scheletro")
        {
            collision.GetComponent<Scheletro>().TakeDamage(25);
            Destroy(gameObject);
        }
           
    }
}
