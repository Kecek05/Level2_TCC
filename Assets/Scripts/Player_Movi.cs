﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movi : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rig;
    private Vector2 direction;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float attackCoolDown = 0.5f;
    [SerializeField] private float attackRadius = 1f;
    private bool isAttacking;
    [SerializeField] private LayerMask enemyLayer;
    private Vector2 attackPos;
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(AttackCoroutine());
        }

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (direction.magnitude > 0)
        {
            animator.SetBool("isWalking", true);


            if (direction.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }

    private IEnumerator AttackCoroutine()
    {
        animator.SetBool("isAttacking", isAttacking);

        if(spriteRenderer.flipX)
        {
            attackPos = new Vector2(transform.position.x + 0.5f, transform.position.y); // left
        } else
        {
            attackPos = new Vector2(transform.position.x - 0.5f, transform.position.y); // right
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos, attackRadius, enemyLayer);


        foreach (Collider2D enemy in hitEnemies)
        {
            Destroy(enemy.gameObject); 
        }

        yield return new WaitForSeconds(attackCoolDown);
        isAttacking = false;
        animator.SetBool("isAttacking", isAttacking);
    }

    // Debug
    private void OnDrawGizmosSelected()
    {
       
        if(spriteRenderer != null)
        {
            // in play mode
            if (spriteRenderer.flipX)
            {
                attackPos = new Vector2(transform.position.x + 0.5f, transform.position.y); // left
            }
            else
            {
                attackPos = new Vector2(transform.position.x - 0.5f, transform.position.y); // right
            }
        } else
        {
            // not in playmode
            attackPos = new Vector2(transform.position.x - 0.5f, transform.position.y); // right

        }


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos, attackRadius);
    }
}
