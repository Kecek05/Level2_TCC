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

    private float attackCoolDown = 2f;
    private bool isAttacking;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private LayerMask enemyLayer;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
        }


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


    private IEnumerator AttackCoroutine()
    {
        animator.SetBool("isAttacking", isAttacking);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, 10f, enemyLayer);

        // Itera sobre todos os inimigos atingidos
        foreach (Collider2D enemy in hitEnemies)
        {
            Destroy(enemy.gameObject); // Destrói o inimigo atingido
            Debug.Log("Inimigo destruído: " + enemy.name);
        }

        yield return new WaitForSeconds(1f);
        isAttacking = false;
        animator.SetBool("isAttacking", isAttacking);
    }

    //Debug
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.transform.position, 10f);
    }
}
