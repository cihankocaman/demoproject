using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject obj;

    private Camera cam;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        cam = Camera.main;
    }
    public void OnClick()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ObjectFactory.GetAbility(transform.parent.tag).Process(obj, mousePos);
    }
}
