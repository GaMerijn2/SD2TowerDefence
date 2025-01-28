using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystemV2 : MonoBehaviour
{
    ObjectSpawner spawner;
    
    [Header("Wave System Variables")]
    public EnemyWave[] waves;
    private bool startWave = false;
    private int currentWaveIndex = 0;

    [Header("UI Variables")]
    [SerializeField] private Button _waveButton;

    void Start()
    {
        spawner = GetComponent<ObjectSpawner>();
        startWave = false;
        Debug.Log("Wave system initialized. Waiting to start waves...");
    }

    void Update()
    {
        if (startWave)
        {
            StartCoroutine(StartWaveCoroutine());
        }
    }

    private IEnumerator StartWaveCoroutine()
    {
        startWave = false;
        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("All waves completed!");
            yield return null;
        }

        var wave = waves[currentWaveIndex];
        Debug.Log($"Starting Wave {currentWaveIndex + 1}: {wave.name}. {wave.enemiesToSpawn.Length} types of enemies to spawn.");

        foreach (var enemyData in wave.enemiesToSpawn)
        {
            for (int i = 0; i < enemyData.amount; i++)
            {
                ScriptableEnemy.EnemyStats enemy = enemyData.ScriptableEnemy.enemyStats;
                GameObject spawnedEnemy = spawner.SpawnObject(enemy.prefab, transform.position);
                spawnedEnemy.GetOrAddComponent<SpawnInfo>().spawner = gameObject;
                spawnedEnemy.GetOrAddComponent<HealthSystem>().health = enemy.health;
                Debug.Log($"Spawned enemy: {enemy.name}");

                yield return new WaitForSeconds(enemyData.spawnDelay);
            }
        }

        Debug.Log($"Completed Wave {currentWaveIndex + 1}.");
        _waveButton.gameObject.SetActive(true);
        currentWaveIndex++;
    }

    public void ToggleStartWaveBool()
    {
        startWave = !startWave;
        Debug.Log($"StartWave set to: {startWave}");
    }
}