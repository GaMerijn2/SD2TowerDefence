using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyWave", menuName = "ScriptableObjects/EnemyWave", order = 1)]
public class EnemyWave : ScriptableObject
{
    [System.Serializable]
    public class EnemySpawn
    {
        public ScriptableEnemy ScriptableEnemy;
        public int amount = 1;
        public float spawnDelay = 1f;
    }

    public string waveName = "DefaultName";
    public EnemySpawn[] enemiesToSpawn;
    public float waveDelay = 5f; // deze moet ik nog even implementen wanneer dat nodig is
}