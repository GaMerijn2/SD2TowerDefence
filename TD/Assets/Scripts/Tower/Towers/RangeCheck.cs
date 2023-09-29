using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCheck : MonoBehaviour
{
    public LayerMask whatIsObject;
    public int sightRange;
    public bool objectInSightRange;
    public GameObject enemy;


    // Update is called once per frame
    void Update()
    {
        CheckIfInRange();
        if (objectInSightRange)
        {
            LookAtObject();
        }
    }

    private void CheckIfInRange()
    {
        objectInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsObject);
        Debug.Log(objectInSightRange);

    }

    private void LookAtObject()
    {
        Debug.Log("Object In Range");
        this.transform.LookAt(enemy.transform.position);
    }
}
