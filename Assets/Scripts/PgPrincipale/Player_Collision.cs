using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour
{
    public bool isInvincible=false;
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
        if (HealthManager.health <= 0)
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(GetHurt());
        }

    }
}
