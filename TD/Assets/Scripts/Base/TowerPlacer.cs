using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    GameGrid gameGrid;
    private GameObject CurrentPlacingTower;

    [SerializeField] private LayerMask whatIsAGridLayer;
    [SerializeField] private LayerMask PlacementCheck;
    [SerializeField] private LayerMask PlacementCollide;
    [SerializeField] public AudioSource placeSound;
    [SerializeField] private bool canPlace;
    [SerializeField] private float towerCooldown;




    // Start is called before the first frame update
    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>();
        canPlace = true;
        towerCooldown = 3f;
    }
    void Update()
    {
        if (CurrentPlacingTower != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo;

            if (Physics.Raycast(ray, out HitInfo, 1000f , /*whatIsAGridLayer*/ PlacementCollide))
            {
                CurrentPlacingTower.transform.position = HitInfo.point;
            }
            if (Input.GetMouseButtonDown(0) && HitInfo.collider.gameObject != null && canPlace)
            {
                if (!HitInfo.collider.gameObject.CompareTag("CantPlace"))
                {
                    BoxCollider TowerCollider = CurrentPlacingTower.gameObject.GetComponent<BoxCollider>();
                    TowerCollider.isTrigger = true;

                    Vector3 BoxCenter = CurrentPlacingTower.gameObject.transform.position + TowerCollider.center;
                    Vector3 HalfExtents = TowerCollider.size / 2;
                    if (Physics.CheckBox(BoxCenter, HalfExtents, Quaternion.identity, PlacementCheck, QueryTriggerInteraction.Ignore))
                    {
                        TowerCollider.isTrigger = false;
                        placeSound.Play();
                        CurrentPlacingTower = null;
                        canPlace = false;
                        Invoke(nameof(resetPlacement), towerCooldown);

                    }

                }
            }
        }
    }
    private void resetPlacement()
    {
        canPlace = true;
    }
    public void SetTowerOfPlace(GameObject Tower)
    {
        Debug.Log("Place Tower");
        CurrentPlacingTower = Instantiate(Tower, Vector3.zero, Quaternion.identity);

    }
}
