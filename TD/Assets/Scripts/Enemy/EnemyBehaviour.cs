using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;


public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] RangeCheck rangeCheck;

    public static event Action OnDeath;

    private void Start()
    {

        
    }
    private void Update()
    {
        if (rangeCheck ??= null)
        {
            rangeCheck = FindObjectOfType<RangeCheck>();

        }
        if (health <= 0)
        {
            rangeCheck.HandleTargetDeath();
            OnDeath.Invoke();
            Destroy(this.gameObject,0f);
            rangeCheck.RemoveTargetFromInRangeList(GetComponent<Enemy>());

            rangeCheck.GetCurrentTarget();
        }
    }
    private void OnTriggerEnter(Collider trigger)
    {
        rangeCheck = FindObjectOfType<RangeCheck>();

        if (trigger.gameObject.name == "BulletObj")
        {
            health -= 10;
        }
    }
}
