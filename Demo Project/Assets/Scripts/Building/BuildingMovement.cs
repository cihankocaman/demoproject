using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMovement : MonoBehaviour
{
    private Placement placeBuilding;
    private Vector2 mousePos;
    private Camera cam;

    void Start()
    {
        placeBuilding = GetComponent<Placement>();
        cam = Camera.main;
    }

    void Update()
    {
        if (!placeBuilding.isPlaced)
        {
            FollowMousePosition();
        }
    }

    private void FollowMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x, mousePos.y);
    }
}
