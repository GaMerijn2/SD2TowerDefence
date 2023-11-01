using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public GameObject enemyPrefab;  // Reference to your enemy prefab.
    public Transform[] waypoints;   // Waypoints for the enemy path.
    public float timeBetweenWaves = 10f;
    public int totalWaves = 5;

    private int currentWave = 0;

    private void Start()
    {
        timeBetweenWaves = 10f;
        StartCoroutine(StartWaves());
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) 
        { 
        SpawnEnemy();
        }
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
        GameObject enemy = Instantiate(enemyPrefab, waypoints[0].position, Quaternion.identity);
        //enemy.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
    }


}
