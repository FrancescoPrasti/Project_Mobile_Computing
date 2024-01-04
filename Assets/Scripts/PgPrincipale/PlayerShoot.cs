using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
     PlayerControls controls;
    public Animator animator;

    public GameObject fireBall;
    public Transform fireBallHole;
    public float force = 5;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Terreno.Shoot.performed += ctx => animator.SetTrigger("shoot");
    }

    void Fire()
    {
        //animator.SetTrigger("shoot");
        GameObject go = Instantiate(fireBall, fireBallHole.position, fireBall.transform.rotation);
        
        if(GetComponent<PlayerMovement>().right)
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        else
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
        Destroy(go, 1.5f);
    }
}
