using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();
    public float range;
    public float attackDelay;

    public LookAtObj lookAtObj;
    public GameObject currentTarget;
    private bool isShooting = false; 

    private void Start()
    {
        lookAtObj = GetComponent<LookAtObj>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Added {other.gameObject.name} to the list");
        targets.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject);
        Debug.Log($"Removed {other.gameObject.name} from the list");
    }

    private void Update()
    {
        if (targets.Count <= 0) return;

        currentTarget = targets[0];

        if (currentTarget != null)
        {
            lookAtObj.LookAt(currentTarget);

            if (!isShooting)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Debug.DrawLine(transform.position, currentTarget.transform.position, Color.red, 0.1f);
        Debug.Log($"Pew");
        yield return new WaitForSeconds(attackDelay);
        isShooting = false;
    }
}