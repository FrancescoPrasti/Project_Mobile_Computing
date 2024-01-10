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

    private void meleeAttack()
    {

        if (isAttacking)
        {
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attaccoCheck.position, attackRange, attaccoLayer);
            for (int i = 0; i < enemiesInRange.Length; i++)
            {
                enemiesInRange[i].GetComponent<Scheletro>().TakeDamage(25);
            }
        }

    }

    public void inizioAttacco()
    {
        isAttacking = true;
    }

    public void fineAttacco()
    {
        isAttacking = false;
    }



}
