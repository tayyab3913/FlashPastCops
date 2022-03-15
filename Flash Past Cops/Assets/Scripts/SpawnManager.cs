using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject collectablePrefab;
    public Transform[] spawnPositions;

    public float spawnDelay = 2;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemiesRoutine());
        SpawnCollectables();
    }

    public void SpawnEnemy()
    {
        int tempIndex = Random.Range(0, spawnPositions.Length);
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPositions[tempIndex].transform.position, enemyPrefab.transform.rotation);
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        while(!GameManager.instance.gameOver)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnEnemy();
        }
    }

    void SpawnCollectables()
    {
        for (int i = 0; i < GameManager.instance.collectablesToWin; i++)
        {
            InstantiateCollectable();
        }
    }

    void InstantiateCollectable()
    {
        int tempIndex = Random.Range(0, spawnPositions.Length);
        GameObject collectable = Instantiate(collectablePrefab, spawnPositions[tempIndex].transform.position, collectablePrefab.transform.rotation);
    }
}
