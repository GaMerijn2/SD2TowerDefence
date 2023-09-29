using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject a, b;
    //  public int WaitTime;
    private Vector3 velocity;
    public float speed = 0.5f;
    private void Start()
    {
        SetPosToA();
    }
    private void Update()
    {
        SetDirection();
    }
    void SetDirection()
    {
        Vector3 Direction = b.transform.position - this.transform.position;
        float Distance = Direction.magnitude;
        Vector3 norm_direction = Direction.normalized;

        velocity = norm_direction * speed;
        this.transform.position += velocity * Time.deltaTime;
        //float angle = Mathf.Atan2(velocity.y, velocity.x);
       // this.transform.localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg);

        if (Distance < velocity.magnitude * Time.deltaTime)
        {
            SetPosToA();
        }
    }
    void SetPosToA()
    {
        this.transform.position = a.transform.position; // set enemy pos to point a pos
    }
}
