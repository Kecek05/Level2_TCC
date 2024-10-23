using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    private GameObject player;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        //cuz its 2D, not rotate
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }


    void Update()
    {
        agent.SetDestination(player.transform.position);

        if (player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //collided with player, go to level 1
            SceneManager.LoadScene("Level1");
        }
    }
}
