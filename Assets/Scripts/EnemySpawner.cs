using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] enemySpawners;
    [SerializeField] private GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(EnemySpawnerCoroutine());
    }

    private IEnumerator EnemySpawnerCoroutine()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, enemySpawners.Length);
            Instantiate(enemyPrefab, enemySpawners[randomIndex].transform);

            yield return new WaitForSeconds(5f);
        }
    }

}
