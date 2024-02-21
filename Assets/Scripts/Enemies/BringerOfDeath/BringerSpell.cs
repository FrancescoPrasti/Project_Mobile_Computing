using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BringerSpell : MonoBehaviour
{
    public Animator animator;
    void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>().isInvincible)
        {
           collision.GetComponent<PlayerCollision>().TakeDamage();
        }
    }

    public void fineFulmine()
    {
        Destroy(gameObject);
    }

    /*public IEnumerator pausaFulmine()
    {
        animator.speed = 0;
        yield return new WaitForSeconds(2);
        animator.speed = 1;
    }*/

    public void pausaFulmine()
    {
        this.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    public void dannoFulmine()
    {
        this.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
