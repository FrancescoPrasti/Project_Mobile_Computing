using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    GameObject target;
    public int enemyHP = 50;
    public Animator animator;

    public GameObject[] itemDrops;
    private bool itemDropped = false;

    public float speed = 2;
    public float range = 3;
    float startingY;
    int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.y;
        target = GameObject.FindGameObjectWithTag("Player");
        //Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target.transform.position.x > transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(target.transform.position.x < transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if(transform.position.y < startingY || transform.position.y > startingY+range)
            dir *= -1;
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if(enemyHP > 0)
        {
            AudioManager.instance.Play("EnemieDamage");
        }
        else if(enemyHP <= 0)
        {
            animator.SetTrigger("vanish");
            death();
        }
    }

    public void distruggi()
    {
        Destroy(this.gameObject);
    }

    public void death()
    {
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
        if (collision.transform.tag == "Player" && HealthManager.health > 0)
        {
            AudioManager.instance.Play("GhostScream");
            collision.GetComponent<PlayerCollision>().TakeDamage();
        }
    }

}
