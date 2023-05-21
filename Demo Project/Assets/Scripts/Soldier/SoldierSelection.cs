using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierSelection : SingletonCreator<SoldierSelection>
{
    public LayerMask soldierLayer;

    private Camera cam;


    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SelectSoldier();
        }
    }
    void SelectSoldier()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, soldierLayer);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<SoldierAI>().enabled = true;
        }
    }
}
