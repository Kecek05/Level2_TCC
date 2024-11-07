using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed;
    private GameObject currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = pointB;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.transform.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, currentPoint.transform.position) < 0.1f)
        {
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
