using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameGrid : MonoBehaviour
{

    private int height = 10;
    private int width = 10;
    private float gridSpaceSize = 50f;

    [SerializeField] private GameObject gridCellPrefab;
    private GameObject[,] gameGrid;

    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        gameGrid = new GameObject[height, width];
        if (gridCellPrefab == null)
        {
            Debug.Log("No Grid");
            return;
        }

        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                gameGrid[x,z] = Instantiate(gridCellPrefab, new Vector3(x * gridSpaceSize, 7, z * gridSpaceSize), Quaternion.identity);
                gameGrid[x,z].GetComponent<GridCell>().SetPosition(x,z);
                gameGrid[x,z].transform.parent = transform;
                gameGrid[x,z].gameObject.name = "Grid Space ( X: " + x.ToString() + ", " + z.ToString() + ")";
            }
        }
        this.transform.position = new Vector3(-350,10,-300);

    }

    // gets the grid position from world position
    public Vector2Int GetGridPosFromWorld(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / gridSpaceSize);
        int z = Mathf.FloorToInt(worldPosition.z / gridSpaceSize);

        x = Mathf.Clamp(x, 0, width);
        z = Mathf.Clamp(x, 0, height);

        return new Vector2Int(x,z);
    }

    // gets the world position of a grid position
    public Vector3 GetWorldPosFromGridPos(Vector2Int gridPos)
    {
        float x = gridPos.x / gridSpaceSize;
        float z = gridPos.y / gridSpaceSize;

        return new Vector3(x, 0, z);
    }
}
