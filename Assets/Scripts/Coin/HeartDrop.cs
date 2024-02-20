using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDrop : MonoBehaviour
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
        if (itemRb != null && itemRb.position.y <= -3.92f)
            Destroy(itemRb.GetComponent<Rigidbody2D>());
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (HealthManager.cuoriColorati < 3)
            {
                AudioManager.instance.Play("Charge");
                HealthManager.health++;
                HealthManager.cuoriColorati++;
                Destroy(gameObject);
            }
        }
        else if(collision.tag == "Terreno")
            Destroy(itemRb.GetComponent<Rigidbody2D>());
    }
}
