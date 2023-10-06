using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    bool destroyBool;
   
    // Start is called before the first frame update
    void Start()
    {
        destroyBool = false;
    }

    void Update()
    {
        GetRidOfObject();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
    private void GetRidOfObject()
    {
        //Debug.Log("Wait");

        destroyBool = false;

        Invoke(nameof(DestroyObjects), 4);

    }

    private void DestroyObjects()
    {
       // Debug.Log("Destroy");
        Destroy(this.gameObject);

        destroyBool = true;
    }
}
