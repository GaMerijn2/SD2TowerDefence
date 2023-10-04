using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{

    [SerializeField] private float size = 1f;
    [SerializeField] private float gridSize = 300f;


    private void Start()
    {
        
    }


    public Vector3 GetNearestPointOnGridSystem(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.FloorToInt(position.x / size);
        int yCount = Mathf.FloorToInt(position.y / size + 1.5f);
        int zCount = Mathf.FloorToInt(position.z / size);

        Vector3 result = new Vector3((float)xCount * size,/* (float)yCount * size*/0f, (float)zCount * size);

        result += transform.position;
        return result;

    }
    private void OnDrawGizmos()
    {
        // Gizmos.color = Color.green;
        for (float x = 0; x < 1; x += size)
        {
            for (float z = 0; z < 1; z += size)
            {
                //Vector3 point = GetNearestPointOnGridSystem(new Vector3(x, 5f, z));
                // Gizmos.DrawSphere(point, 5f);
            }
        }
    }
}
