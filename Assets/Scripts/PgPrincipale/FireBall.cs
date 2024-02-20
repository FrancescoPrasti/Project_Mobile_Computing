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
        else if(collision.tag == "BringerOfDeath")
        {
            collision.GetComponent<BringerOfDeath>().TakeDamage(50);
            Destroy(gameObject);
        }
        else if(collision.tag == "FlyingEye")
        {
            collision.GetComponent<Eye>().TakeDamage(50);
            Destroy(gameObject);
        }
        else if(collision.tag == "Demon")
        {
            collision.GetComponent<Demon>().TakeDamage(50);
            Destroy(gameObject);
        }
        else if(collision.tag == "Necromancer")
        {
            collision.GetComponent<Necromancer>().TakeDamage(50);
            Destroy(gameObject);
        }
        else if(collision.tag == "ScheletroTutorial")
        {
            collision.GetComponent<EvocazioneScheletroTutorial>().TakeDamage(50);
            Destroy(gameObject);
        }
    }
}
