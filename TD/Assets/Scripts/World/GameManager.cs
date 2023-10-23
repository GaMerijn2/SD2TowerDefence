using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform spawnLocation;
    public GameObject enemyPrefab;  // Reference to your enemy prefab.
    public float timeBetweenWaves = 5f;
    public int totalWaves = 5;

    private int currentWave = 0;

    private void Start()
    {
        StartCoroutine(StartWaves());
    }

    private IEnumerator StartWaves()
    {
        while (currentWave < totalWaves)
        {
            SpawnWave();
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void SpawnWave()
    {
        currentWave++;

        for (int i = 0; i < currentWave; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnLocation.transform.position, Quaternion.identity);
    }

}
