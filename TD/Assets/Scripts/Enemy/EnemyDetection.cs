using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField]
    private RangeCheck rangeCheck;


    private void Start()
    {
        rangeCheck ??= GetComponent<RangeCheck>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy In Range");

            rangeCheck.AddTargetToInRangeList(other.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Out Of Range");

            rangeCheck.RemoveTargetFromInRangeList(other.GetComponent<Enemy>());

        }
    }
}
