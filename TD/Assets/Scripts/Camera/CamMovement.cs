using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CamMove();
    }
    void CamMove()
    {
        float UpDown = Input.GetAxisRaw("Mouse ScrollWheel");

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, UpDown + 1, vertical).normalized;

        direction = direction * speed;

        controller.Move(direction * Time.deltaTime);


    }
}
