using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject CurrentPlacingTower;


    public void SetTowerOfPlace(GameObject Tower)
    {
        Debug.Log("Place Tower");
        CurrentPlacingTower = Instantiate(Tower, Vector3.zero, Quaternion.identity);
    }
}
