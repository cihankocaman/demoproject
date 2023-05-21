using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Overlap : MonoBehaviour
{
    private Placement placeBuilding;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        placeBuilding = GetComponent<Placement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        placeBuilding.isPlaceable = false;
        if (!placeBuilding.isPlaced)
        {
            spriteRenderer.color = Color.red;
            spriteRenderer.sortingOrder = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!placeBuilding.isPlaced)
        {
            spriteRenderer.color = Color.white;
            spriteRenderer.sortingOrder = 0;
        }
        placeBuilding.isPlaceable = true;
    }
}
