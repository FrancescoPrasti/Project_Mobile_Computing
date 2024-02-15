using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaccoPlayer : MonoBehaviour
{

    PlayerControls controls;
    public Animator animator;

    public Transform attaccoCheck;
    public LayerMask attaccoLayer;
    public float attackRange;

    bool isAttacking = false;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Terreno.Attacco.performed += ctx =>
        {
            animator.SetTrigger("attacco");
        };
    }

    void FixedUpdate()
    {
        if(PlayerManager.isGameOver == true){
            controls.Disable();
        }
    }

    private void meleeAttack()
    {

        if (isAttacking)
        {
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attaccoCheck.position, attackRange, attaccoLayer);
            for (int i = 0; i < enemiesInRange.Length; i++)
            {
                if(enemiesInRange[i].tag == "Scheletro")
                    enemiesInRange[i].GetComponent<Scheletro>().TakeDamage(25);
                else if(enemiesInRange[i].tag == "Ghost")
                    enemiesInRange[i].GetComponent<Ghost>().TakeDamage(25);
                else if(enemiesInRange[i].tag == "BringerOfDeath")
                    enemiesInRange[i].GetComponent<BringerOfDeath>().TakeDamage(25);
            }
        }

    }

    public void inizioAttacco()
    {
        //this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.5f);
        isAttacking = true;
        controls.Disable();
    }

    public void fineAttacco()
    {
        isAttacking = false;
        controls.Enable();
    }



}
