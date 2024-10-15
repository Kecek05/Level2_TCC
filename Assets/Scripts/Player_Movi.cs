using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movi : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rig;
    private Vector2 direction;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        if (direction.magnitude > 0)
        {
            //walking
            animator.SetBool("isWalking", true);

            
            if (direction.x < 0)
            {
                spriteRenderer.flipX = false; // flip left
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = true; // flip right
            }

        }
        else
        {
            // idle
            animator.SetBool("isWalking", false);
        }

    }
    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }

}
