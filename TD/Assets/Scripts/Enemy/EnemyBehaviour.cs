using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] RangeCheck rangeCheck;

    private void Start()
    {
    }
    private void Update()
    {
        if (rangeCheck ??= null)
        {
           // rangeCheck = GetComponent<RangeCheck>();
            rangeCheck = FindObjectOfType<RangeCheck>();

        }
        if (health <= 0)
        {
            rangeCheck.HandleTargetDeath();

        }
    }
    private void OnTriggerEnter(Collider trigger)
    {
        rangeCheck = FindObjectOfType<RangeCheck>();

        Debug.Log(trigger.gameObject.name);
        if (trigger.gameObject.name == "BulletObj")
        {
            Debug.Log("Enemy hit");
            health -= 100;
            Debug.Log("EnemyHealth: " + health);
            if (health <= 0)
            {
                rangeCheck.HandleTargetDeath();

            }
        }
    }
}
