using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
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
}
