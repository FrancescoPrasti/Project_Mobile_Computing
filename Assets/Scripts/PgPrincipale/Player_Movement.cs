using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variabili movimento orizzontale
    public PlayerControls controls;
    public Rigidbody2D player;
    private float direction = 0;
    public float speed = 400;

    // Variabili salto
    public float salto = 5;
    bool aTerra;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Variabili animazioni
    public Animator animator;
    public bool right = true;

    


    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Terreno.Movimento.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Terreno.Salto.performed += ctxs => Salto();
        
    }

    void FixedUpdate()
    {
        /*if(PlayerManager.isGameOver == true && aTerra == true){
            controls.Disable();
            Destroy(GetComponent<Rigidbody2D>());
        }*/
        if(PlayerManager.isGameOver == true){
            controls.Disable();
        }
        else{
            aTerra = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
            animator.SetBool("aTerra", aTerra);

            player.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, player.velocity.y);
            animator.SetFloat("speed", Mathf.Abs(direction));

            if(right && direction < 0 || !right && direction > 0)
            {
                Inverti();
            }
        }
    }

    void Inverti()
    {
        right = !right;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Salto()
    {
        if (aTerra)
        {
            AudioManager.instance.Play("Jump");
            player.velocity = new Vector2(player.velocity.x, salto);
        }

    }
}
