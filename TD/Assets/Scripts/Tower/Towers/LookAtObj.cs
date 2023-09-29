using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObj : MonoBehaviour
{
    public GameObject LookatObject;
    private GameObject WillBeLookingAtObject;
    public int ChildObj;
    // Start is called before the first frame update
    void Start()
    {
        WillBeLookingAtObject = this.gameObject.transform.GetChild(ChildObj).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        WillBeLookingAtObject.transform.LookAt(LookatObject.transform.position);
    }
}
