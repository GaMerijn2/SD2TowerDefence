using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObj : MonoBehaviour
{
    public GameObject lookingObject;

    public void LookAt(GameObject target)
    {
        lookingObject.transform.LookAt(target.transform);
    }
}
