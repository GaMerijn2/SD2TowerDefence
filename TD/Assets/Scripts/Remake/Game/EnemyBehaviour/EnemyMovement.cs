using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy Stats")] 
    public ScriptableEnemy stats;
    public SpawnInfo spawnInfo;
    
    [Header("Movement Variables")]
    public NavMeshAgent agent;
    
    [Header("Waypoint Variables")]
    public WaypointSystem waypointSystem;
    public GameObject[] waypoints;
    public int currentWaypoint;
    public float distanceTreshold = 1f;

    private bool isWaypointReached = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnInfo = GetComponent<SpawnInfo>();
        waypointSystem = spawnInfo.spawner.GetComponent<WaypointSystem>();
        waypoints = waypointSystem.WayPoints;
        agent.speed = stats.enemyStats.speed;
    }

    void Update()
    {
        FollowWaypoints();
    }

    private void FollowWaypoints()
    {
        if (currentWaypoint >= waypoints.Length) return;

        agent.SetDestination(waypoints[currentWaypoint].transform.position);

        if (!isWaypointReached && agent.remainingDistance <= distanceTreshold && !agent.pathPending)
        {
            isWaypointReached = true; 
            currentWaypoint += 1;
            StartCoroutine(ResetWaypointFlag());
        }
    }

    private IEnumerator ResetWaypointFlag()
    {
        yield return new WaitForEndOfFrame();
        isWaypointReached = false;
    }
}