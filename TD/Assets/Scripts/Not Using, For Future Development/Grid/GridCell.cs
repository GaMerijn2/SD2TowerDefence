using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    private int posX;
    private int posZ;

    // saves a reference to the GameObject that gets placed in this cell
    public GameObject objectInThisGridSpace = null;

    //saves if the grid space is occupied
    public bool isOccupied = false;
    
    //set the position of this grid cell on the grid
    public void SetPosition(int x, int z)
    {
        posX = x;
        posZ = z;
    }
    public Vector2Int GetPosition()
    {
        return new Vector2Int(posX, posZ);
    }
}
