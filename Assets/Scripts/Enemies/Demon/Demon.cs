using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Demon : MonoBehaviour
{
    public Animator animator;
    public GameObject fiamma;
    public float spawnInzialeFiamme = 24.91f;
    public float secondsWait;
    public static int enemyHP = 200;
    int j;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        j = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void InizioAttacco()
    {
        animator.SetBool("IsAttacking", true);
    }

    public void ContinuoAttacco()
    {
        animator.SetTrigger("Continue");
    }

    public IEnumerator SpawnFiammata()
    {
        AudioManager.instance.Play("DemonAttack");
        for(int i=0; i<20; i++)
        {
            Instantiate(fiamma, new Vector2(spawnInzialeFiamme - i, 1.16f), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator FineAttacco()
    {
        if(j < 3)
        {
            j++;
            Debug.Log(j);
        }
        else
        {
            AudioManager.instance.Stop("DemonAttack");
            j = 0;
            animator.SetBool("IsAttacking", false);
            SpawnFiammata();
            yield return new WaitForSeconds(secondsWait);
            InizioAttacco();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        Debug.Log(enemyHP);
        if(enemyHP > 0)
        {
            AudioManager.instance.Play("EnemieDamage");
        }
        else if(enemyHP <= 0)
        {
            if(isDead == false)
            {
                animator.SetTrigger("Death");
                isDead = true;
            }
        }
    }

    public IEnumerator Danno()
    {
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetLayerWeight(1, 0);
    }
}
