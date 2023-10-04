using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    private GridSystem gridSystem;
    [SerializeField] private GameObject gridCellPrefab;


    private void Awake()
    {
        gridSystem = FindObjectOfType<GridSystem>();
    }

    private void Update()
    {
        CheckMouse();
    }

    private void CheckMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.tag != "Platform")
                {
                    PlaceObjectNear(hitInfo.point);
                }
            }   
        }
    }
    
    private void PlaceObjectNear(Vector3 clickPoint)
    {
        Vector3 finalPosition = gridSystem.GetNearestPointOnGridSystem(clickPoint);
       // GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = finalPosition;
        Instantiate(gridCellPrefab).transform.position = finalPosition;
    }

}
