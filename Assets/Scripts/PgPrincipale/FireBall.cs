using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Scheletro")
        {
            collision.GetComponent<Scheletro>().TakeDamage(50);
            Destroy(gameObject);
        }
        else if(collision.tag == "Ghost")
        {
            collision.GetComponent<Ghost>().TakeDamage(50);
            Destroy(gameObject);
        }
           
    }
}
