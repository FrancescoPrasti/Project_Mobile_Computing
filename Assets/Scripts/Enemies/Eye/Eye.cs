using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Eye : MonoBehaviour
{
    GameObject target;
    public int enemyHP = 50;
    public Animator animator;

    public GameObject[] itemDrops;
    private bool itemDropped = false;

    public float speed = 2;
    public float range = 3;
    float startingX;
    int dir = 1;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        target = GameObject.FindGameObjectWithTag("Player");
        //Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enemyHP > 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
            if(transform.position.x < startingX)
            {
                dir = 1;
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if(transform.position.x > startingX + range)
            {
                dir = -1;
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else
            Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if(enemyHP > 0)
        {
            animator.SetTrigger("Damage");
        }
        else if(enemyHP <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<CircleCollider2D>().enabled = false;
            /*if(isDead == false)
            {
                animator.SetTrigger("Death");
                isDead = true;
            }*/
        }
    }

    public void death()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 1;
        this.GetComponent<CircleCollider2D>().radius = 0.4f;
        if (itemDropped == false)
        {
            ItemDrop();
            itemDropped = true;
        }
    }

    public void PlayerDamage()
    {
        if (!target.GetComponent<PlayerCollision>().isInvincible)
        {
            target.GetComponent<PlayerCollision>().TakeDamage();
        }
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")// && HealthManager.health > 0)
        {
           animator.SetBool("IsAttacking", true);
        }
        else if(collision.transform.tag == "Terreno")
        {
            Destroy(this.GetComponent<Rigidbody2D>());
            //this.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(HealthManager.health <= 0)
            animator.SetBool("IsAttacking", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
           animator.SetBool("IsAttacking", false);
        }
    }

}
