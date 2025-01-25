using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private IEnumerator SpawnObject(GameObject obj, int amount, float delayTime, Vector3 position)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(obj, position, Quaternion.identity);
            yield return new WaitForSeconds(delayTime);        
        }
    }
    
    public void StartSpawning(GameObject obj, int amount, float delayTime, Vector3 position)
    {
        StartCoroutine(SpawnObject(obj, amount, delayTime, position));
    }
}
