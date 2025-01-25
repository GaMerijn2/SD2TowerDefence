using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystemV2 : MonoBehaviour
{
    ObjectSpawner spawner;
    public EnemyWave[] waves;

    void Start()
    {
        spawner = GetComponent<ObjectSpawner>();
        StartWave();
    }

    private void StartWave()
    {
        foreach (var wave in waves)
        {
            foreach (var enemies in wave.enemiesToSpawn)
            {
                ScriptableEnemy.EnemyStats enemy = enemies.ScriptableEnemy.enemyStats;
                spawner.StartSpawning(enemy.prefab, enemies.amount, enemies.spawnDelay, transform.position);
            }
        }
    }
}
