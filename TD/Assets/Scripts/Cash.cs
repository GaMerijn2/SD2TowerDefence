using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public static int cashAmount;
    void Start()
    {
        cashAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
