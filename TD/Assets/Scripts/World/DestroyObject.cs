using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    bool destroyBool;
    [SerializeField] public int destroyCooldown = 4;
   
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

        destroyBool = false;

        Invoke(nameof(DestroyObjects), destroyCooldown);

    }

    private void DestroyObjects()
    {
        Destroy(this.gameObject);

        destroyBool = true;
    }
}
