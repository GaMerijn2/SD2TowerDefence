using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject movePoint1, movePoint2;
    bool move;
    bool activate;
    void Start()
    {
        this.transform.position = movePoint1.transform.position;
        activate = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if(move)
        {
            this.transform.position = Vector3.Lerp(movePoint1.transform.position, movePoint2.transform.position, Time.deltaTime * 1);
        }
        Vector3 distance = this.transform.position - movePoint2.transform.position;
        Vector3 direction = distance.normalized;

        if (distance.magnitude <= 0.5)
        {
            move = false;   
        }

      //  Debug.Log("asd");

        if (activate)
        {
            Invoke(nameof(functionName), 1);


            activate = false;
        }
    }
    private void functionName()
    {
        Debug.Log("SD");
        activate = true;
    }
}
