using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int BaseHealth { get;  set; }
    public event Action OnDeath;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(GameObject.FindWithTag("EndPoint").transform.position);
    }
}
