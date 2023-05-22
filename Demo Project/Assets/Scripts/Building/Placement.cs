using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Placement : MonoBehaviour
{
    public bool isPlaced;
    public bool isPlaceable;

    public static Action UpdatePathfinder;

    private BoxCollider2D boxCollider;

    void Start()
    { 
        isPlaced = false;
        isPlaceable = true;

        boxCollider = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            PlaceBuilding();
        }
    }
    void PlaceBuilding()
    {
        if (isPlaceable && !isPlaced)
        {
            transform.position = transform.position;
            isPlaced = true;
            isPlaceable = false;

            ObjectCreator.isObjCreated = false;

            boxCollider.isTrigger = false;

            UpdatePathfinder?.Invoke();
        }
    }
}
