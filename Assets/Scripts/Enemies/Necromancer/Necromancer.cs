using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : MonoBehaviour
{
    GameObject target;
    public int enemyHP = 250;
    public Animator animator;

    public GameObject[] itemDrops;
    private bool itemDropped = false;

    public GameObject FireSkull;
    public GameObject Skeleton;
    public Transform FireSkullHole;
    public float force = 5;
    public static bool inizio = true;
    public DialogoFinale df;
    //public GameObject wall;

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
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if(inizio == true && (Vector2.Distance(target.transform.position, animator.transform.position) <= 9) && DialogueManager.isActive==false)
        {
            //this.gameObject.SetActive(true);
            inizio = false;
            //wall.SetActive(true);
            animator.SetBool("IsAttacking", true);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Danno");
        enemyHP -= damageAmount;
        if(enemyHP > 0)
        {
            AudioManager.instance.Play("EnemieDamage");
            animator.SetTrigger("Damage");
        }
        else
        {
            AudioManager.instance.Play("NecromancerDeath");
            AudioManager.instance.Stop("BossFight");
            AudioManager.instance.Play("Victory");
            animator.SetTrigger("Death");
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
            PlayerManager.Score += 1000;
            PlayFabManager.instance.SendLeaderboard(PlayerManager.Score);
        }
    }

    public void death()
    {
        if (itemDropped == false)
        {
            ItemDrop();
            itemDropped = true;
        }
        df.Fin();
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

    public void FireN()
    {
        AudioManager.instance.Play("NecromancerShoot");
        GameObject go = Instantiate(FireSkull, FireSkullHole.position, FireSkull.transform.rotation);
        if (target.transform.position.x < this.transform.position.x)
        {
            //this.GetComponent<SpriteRenderer>().flipX = true;
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
        }
        else
        {
            //this.GetComponent<SpriteRenderer>().flipX = false;
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        }

        //go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);

        Destroy(go, 5f);
    }

    public void Evocazione()
    {
        GameObject go = Instantiate(Skeleton, new Vector2(this.transform.position.x - 1f, -3.66f), Skeleton.transform.rotation);
    }
    
    public IEnumerator Shoot()
    {
        animator.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(3);
        animator.SetBool("IsShooting", true);
    }

    public IEnumerator Evoc()
    {
        animator.SetBool("IsShooting", false);
        yield return new WaitForSeconds(3);
        animator.SetBool("IsAttacking", true);
    }

    public void setEvocazione()
    {
        animator.SetTrigger("setAttack");
    }
}
