using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scheletro : MonoBehaviour
{
    Transform target;
    public int enemyHP = 100;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-3.75f,3.75f);
        }else
        {
            transform.localScale = new Vector2(3.75f,3.75f);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if(enemyHP > 0)
        {
            animator.SetTrigger("Damage");
        }
        else
        {
            animator.SetTrigger("Death");
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
            /*float posY = transform.position.y;
            posY = -4.45f;*/
            //transform.position = new Vector2(transform.position.x, -4.45f);
            //transform.localScale = new Vector2(3.75f,3.75f);
        }
    }

    public void death()
    {
        transform.position = new Vector2(transform.position.x, -4.45f);

        if(ManaManager.mana < 3)
        {
            ManaManager.mana++;
        }

    }
}
