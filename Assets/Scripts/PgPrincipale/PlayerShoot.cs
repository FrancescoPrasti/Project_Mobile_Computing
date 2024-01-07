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
        if (ManaManager.mana != 0)
        {
            //animator.SetTrigger("shoot");
            GameObject go = Instantiate(fireBall, fireBallHole.position, fireBall.transform.rotation);
            ManaManager.mana--;

            if (GetComponent<PlayerMovement>().right)
            {
                go.transform.localScale = new Vector2(3, 3);
                go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
            }
            else
            {
                go.transform.localScale = new Vector2(-3, 3);
                go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
            }
            Destroy(go, 1.5f);
        }
    }
}
