using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContent : MonoBehaviour
{
    private RectTransform rectTransform;
    private RectTransform[] rtChildren;
    private float width, height;                   /// The width & height of the scroll content.
    private float childWidth, childHeight;         /// The width & height for each child of the scroll view.
    [SerializeField] private float verticalMargin; /// How much the items are indented from top and bottom of the scroll view.

    public float VerticalMargin { get { return verticalMargin; } }
    public float Width { get { return width; } }
    public float Height { get { return height; } }
    public float ChildWidth { get { return childWidth; } }
    public float ChildHeight { get { return childHeight; } }


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rtChildren = new RectTransform[rectTransform.childCount];

        for (int i = 0; i < rectTransform.childCount; i++)
        {
            rtChildren[i] = rectTransform.GetChild(i) as RectTransform;
            rtChildren[i].localPosition = Vector3.zero;
            rtChildren[i].localScale = Vector3.one;
        }

        height = rectTransform.rect.height - (2 * verticalMargin);

        childWidth = rtChildren[0].rect.width;
        childHeight = rtChildren[0].rect.height;

        InitializeContent();

    }

    private void InitializeContent()
    {
        float originY = 0 - (height * 0.5f);
        float posOffset = childHeight * 0.5f;
        for (int i = 0; i < rtChildren.Length; i++)
        {
            Vector2 childPos = rtChildren[i].localPosition;
            childPos.y = originY + posOffset + i * (childHeight);
            rtChildren[i].localPosition = childPos;
        }
    }
}
