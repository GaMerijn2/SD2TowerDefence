using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewEnemy", menuName = "ScriptableObjects/Enemy", order = 1)]

public class ScriptableEnemy : ScriptableObject
{
    [System.Serializable]
    public class EnemyStats
    {
        public string name = "DefaultEnemyName";
        public GameObject prefab;
        public float speed = 1f;
        public int health = 50;
    }

    public EnemyStats enemyStats;
}
