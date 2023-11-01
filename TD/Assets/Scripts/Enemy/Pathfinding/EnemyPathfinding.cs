
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EnemyPathfinding : MonoBehaviour
{
    

    NavMeshAgent agent;
    [SerializeField] float decisionDelay = 0.5f;
    [SerializeField] public float WaypointDistance = 25f;
    [SerializeField] public GameObject[] currentWaypoints;
    [SerializeField] public GameObject[] waypoints1;
    [SerializeField] public GameObject[] waypoints2;
    [SerializeField] public GameObject[] waypoints3;

    int currentWaypoint = 0;

    private void Start()
    {
        WaypointDistance = 25f;
        agent = GetComponent<NavMeshAgent>();

        waypoints1 = GameObject.FindGameObjectsWithTag("Path");
        waypoints2 = GameObject.FindGameObjectsWithTag("Path2");
        waypoints3 = GameObject.FindGameObjectsWithTag("Path3");
        SetPath();
       // Debug.Log(currentWaypoint);
    }
    private void Update()
    {
        agent.SetDestination(currentWaypoints[currentWaypoint].transform.position);
        Vector3 Direction = this.transform.position - currentWaypoints[currentWaypoint].transform.position;
       //transform.LookAt(waypoints[currentWaypoint +1].transform.position, Vector3.left);
        Vector3 NormalizedDir = Direction.normalized;
       if (agent.remainingDistance < WaypointDistance)
        {
            currentWaypoint++;
            Debug.Log(currentWaypoint);
        }
        if (currentWaypoint == currentWaypoints.Length-1)
        {
           agent.SetDestination(this.transform.position);
        }
    }
    private void SetPath()
    {
        int whatPath = Random.Range(1, 4);
        if (whatPath == 1)
        {
            Debug.Log("I Chose Path 1");
            currentWaypoints = waypoints1;
        }
        else if (whatPath == 2)
        {
            Debug.Log("I Chose Path 2");
            currentWaypoints = waypoints2;
        }
        else if (whatPath == 3)
        {
            Debug.Log("I Chose Path 3");
            currentWaypoints = waypoints3;
        }
    }
    
}

