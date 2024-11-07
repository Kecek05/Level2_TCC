using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatroll : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed;
    private GameObject currentPoint;


    private void Start()
    {
        currentPoint = pointB;
    }

    private void Update()
    {
        // Move towards the current point
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.transform.position, speed * Time.deltaTime);

        // Check if the enemy has reached the current point
        if (Vector2.Distance(transform.position, currentPoint.transform.position) < 0.1f)
        {
            // go to the other point
            if(currentPoint == pointA)
            {
                currentPoint = pointB;
            } else
            {
                currentPoint = pointA;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collided with player, restart level
            SceneManager.LoadScene("Level1");
        }
    }
}
