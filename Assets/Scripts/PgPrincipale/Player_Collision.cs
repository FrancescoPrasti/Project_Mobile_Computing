using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Scheletro")
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
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
}
