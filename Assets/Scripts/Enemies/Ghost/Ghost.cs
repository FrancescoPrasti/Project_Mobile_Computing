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
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
        }
        else if(target.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(-1*transform.localScale.x, transform.localScale.y);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if(transform.position.y < startingY || transform.position.y > startingY+range)
            dir *= -1;
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        /*if(enemyHP > 0)
        {
            animator.SetTrigger("Damage");
        }
        else*/
        if(enemyHP <= 0)
        {
            animator.SetTrigger("Vanish");
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
            
        }
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

}
