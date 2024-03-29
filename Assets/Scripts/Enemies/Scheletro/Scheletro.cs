using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scheletro : MonoBehaviour
{
    GameObject target;
    public int enemyHP = 100;
    public Animator animator;

    public GameObject[] itemDrops;
    private bool itemDropped = false;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-3.75f,3.75f);
        }
        else
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
            
        }
    }

    public void death()
    {
        transform.position = new Vector2(transform.position.x, -4.45f);

        if (itemDropped == false)
        {
            ItemDrop();
            itemDropped = true;
        }
        /*if(ManaManager.mana < 3)
        {
            ManaManager.mana++;
        }*/

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
