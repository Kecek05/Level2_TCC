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

    private float attackCoolDown = 0.5f;
    [SerializeField] private float attackRadius = 1f;
    private bool isAttacking;
    [SerializeField] private LayerMask enemyLayer;

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

            // Define a direção do sprite e ajusta o ponto de ataque
            if (direction.x < 0)
            {
                spriteRenderer.flipX = false; // olhando para a esquerda
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = true; // olhando para a direita
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

        // Define um deslocamento de posição com base na direção do personagem
        Vector2 attackPosition = (spriteRenderer.flipX)
            ? new Vector2(transform.position.x + 0.5f, transform.position.y) // Direita
            : new Vector2(transform.position.x - 0.5f, transform.position.y); // Esquerda

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPosition, attackRadius, enemyLayer);

        // Itera sobre todos os inimigos atingidos
        foreach (Collider2D enemy in hitEnemies)
        {
            Destroy(enemy.gameObject); // Destrói o inimigo atingido
            Debug.Log("Inimigo destruído: " + enemy.name);
        }

        yield return new WaitForSeconds(attackCoolDown);
        isAttacking = false;
        animator.SetBool("isAttacking", isAttacking);
    }

    // Debug
    private void OnDrawGizmosSelected()
    {
        Vector2 attackPosition = (spriteRenderer != null && spriteRenderer.flipX)
            ? new Vector2(transform.position.x + 0.5f, transform.position.y)
            : new Vector2(transform.position.x - 0.5f, transform.position.y);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition, attackRadius);
    }
}
