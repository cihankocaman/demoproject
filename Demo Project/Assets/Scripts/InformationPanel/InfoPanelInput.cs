using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfoPanelInput : MonoBehaviour
{
    private Camera cam;
    private InfoPanelPresenter infoPanelPresenter;

    public LayerMask infoLayer;
    
    
    void Start()
    {
        cam = Camera.main;
        infoPanelPresenter = GetComponent<InfoPanelPresenter>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, infoLayer);
            if (hit.collider != null)
            {
                GameObject hitObj = hit.collider.gameObject;
                infoPanelPresenter.ShowBuildingInfo(hitObj);
            }
            else
            {
                infoPanelPresenter.DisableInfoPanel();
            }
        }
    }
}
