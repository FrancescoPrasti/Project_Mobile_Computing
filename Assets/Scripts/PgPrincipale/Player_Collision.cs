using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour
{
    public bool isInvincible=false;
    public Animator animator;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Scheletro")
        {


            TakeDamage();


        }
    }
    IEnumerator GetHurt()
    {
        AudioManager.instance.Play("Damage");
        Physics2D.IgnoreLayerCollision(6, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        isInvincible = true;
        yield return new WaitForSeconds(3);
        isInvincible = false;
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }

    public void TakeDamage()
    {
        HealthManager.health--;
        HealthManager.cuoriColorati--;
        //HealthManager.health = 0;
        if (HealthManager.health <= 0)
        {
            animator.SetTrigger("Death");
            PlayerManager.isGameOver = true;
            AudioManager.instance.Stop("VillageMusic");
        }
        else
        {
            StartCoroutine(GetHurt());
        }

    }
}
