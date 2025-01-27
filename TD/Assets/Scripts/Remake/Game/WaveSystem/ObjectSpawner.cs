using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject SpawnObject(GameObject obj, Vector3 position)
    {
        return Instantiate(obj, position, Quaternion.identity);
    }
}
