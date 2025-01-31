using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int health;
    

    public int GetHealth()
    {
        return health;
    }

    private void SetHealth(int health)
    {
        this.health = health;
    }

    private void Start()
    {
        ScriptableEnemy stats = gameObject.GetComponent<EnemyMovement>().stats;

        SetHealth(stats.enemyStats.health);
    }
}
