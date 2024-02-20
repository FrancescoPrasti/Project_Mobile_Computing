using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeath : MonoBehaviour
{
    GameObject target;
    public int enemyHP = 100;
    public Animator animator;

    public GameObject[] itemDrops;
    private bool itemDropped = false;

    public GameObject spell;
    //GameObject go = null;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        if (target.transform.position.x > transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }*/

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if(enemyHP > 0)
        {
            AudioManager.instance.Play("EnemieDamage");
            animator.SetTrigger("Damage");
        }
        else
        {
            animator.SetTrigger("Death");
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
            PlayerManager.Score += 500;
            
        }
    }

    public void death()
    {
        //transform.position = new Vector2(transform.position.x, -4.45f);

        if (itemDropped == false)
        {
            ItemDrop();
            itemDropped = true;
        }
        /*if(ManaManager.mana < 3)
        {
            ManaManager.mana++;
        }*/
        Destroy(gameObject);
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

    public void inizioFulmine()
    {
        Instantiate(spell, new Vector2(target.transform.position.x, target.transform.position.y + 1.5f), spell.transform.rotation);
    }
}
