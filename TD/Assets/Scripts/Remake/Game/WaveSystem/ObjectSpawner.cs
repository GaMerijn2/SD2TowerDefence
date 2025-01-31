using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject SpawnObject(GameObject obj, Vector3 position)
    {
        Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);

        return Instantiate(obj, position, rotation);
    }
}
