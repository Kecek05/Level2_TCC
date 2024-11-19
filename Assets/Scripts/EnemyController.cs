using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    private GameObject player;
    [SerializeField] private SpriteRenderer spriteRenderer;


    void Start()
    {
        player = GameObject.FindWithTag("Player");

        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }


    void Update()
    {
        agent.SetDestination(player.transform.position);

        if (player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
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
