using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaccoPlayer : MonoBehaviour
{

    PlayerControls controls;
    public Animator animator;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Terreno.Attacco.performed += ctx => Attacco();
    }

    void Attacco()
    {
        animator.SetTrigger("attacco");
    }



}
