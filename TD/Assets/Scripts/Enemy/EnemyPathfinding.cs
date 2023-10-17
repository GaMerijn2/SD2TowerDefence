
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyPathfinding : MonoBehaviour
{


    NavMeshAgent agent;
    [SerializeField] float decisionDelay = 0.5f;
    [SerializeField] public GameObject[] waypoints;
    int currentWaypoint = 0;

    private void Update()
    {
        agent.SetDestination(waypoints[currentWaypoint].transform.position);
        Vector3 Direction = this.transform.position - waypoints[currentWaypoint].transform.position;
        Vector3 NormalizedDir = Direction.normalized;
       // if (Vector3.Distance(this.transform.position, waypoints[currentWaypoint].transform.position <3))

       // {
        //    currentWaypoint++;
       // }
    }
    private void NextWaypoint()
    {
        
    }
}

