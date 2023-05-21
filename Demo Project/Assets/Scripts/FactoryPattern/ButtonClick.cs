using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject obj;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        ObjectFactory.GetAbility(transform.parent.tag).Process(obj);
    }
}
