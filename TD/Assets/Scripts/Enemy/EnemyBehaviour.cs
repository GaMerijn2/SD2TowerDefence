using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;


public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] RangeCheck[] rangeChecks;

    public static event Action OnDeath;

    private void Update()
    {
        rangeChecks = FindObjectsOfType<RangeCheck>();

        if (health <= 0)
        {
            //rangeCheck.HandleTargetDeath();
            OnDeath?.Invoke();
            Cash.cashAmount += (50);
           // EnemyGiveCash.MoneyDisplay.text = "Money: " + Cash.cashAmount.ToString();

            Destroy(this.gameObject,0f);

            for (int i = 0; i < rangeChecks.Length; ++i)
            {
                rangeChecks[i].RemoveTargetFromInRangeList(GetComponent<Enemy>());
                rangeChecks[i].GetCurrentTarget();
            }
        }
    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "BulletObj")
        {
            health -= 10;
        }
        if (trigger.gameObject.name == "EndPoint")
        {
            health -= 100;
        }
    }
}
