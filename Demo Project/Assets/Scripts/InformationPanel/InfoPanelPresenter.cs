using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelPresenter : MonoBehaviour
{
    public Image buildingImage;
    public Image productionImage;

    public void ShowBuildingInfo(GameObject hitObj)
    {
        buildingImage.gameObject.SetActive(true);
        buildingImage.sprite = hitObj.GetComponent<SpriteRenderer>().sprite;
        if (hitObj.transform.childCount > 0)
        {
            productionImage.gameObject.SetActive(true);
            productionImage.sprite = hitObj.GetComponent<SoldierCreator>().soldier.GetComponent<SpriteRenderer>().sprite;
            productionImage.color = hitObj.GetComponent<SoldierCreator>().soldier.GetComponent<SpriteRenderer>().color;
        }
        else
        {
            productionImage.gameObject.SetActive(false);
        }
    }

    public void DisableInfoPanel()
    {
        productionImage.gameObject.SetActive(false);
        buildingImage.gameObject.SetActive(false);
    }
}
