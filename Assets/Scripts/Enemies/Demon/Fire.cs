using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Animator animator;

    public void LoopActivation()
    {
        animator.SetTrigger("Loop");
    }

    public void EndActivation()
    {
        animator.SetTrigger("End");
    }

    public void Distruggi()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && HealthManager.health > 0)
        {
            collision.GetComponent<PlayerCollision>().TakeDamage();
        }
    }
}
