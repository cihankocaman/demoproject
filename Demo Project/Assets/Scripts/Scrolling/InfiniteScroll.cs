using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    /// The ScrollContent component that belongs to the scroll content GameObject.
    [SerializeField] private ScrollContent scrollContent;

    /// The ScrollRect component for this GameObject.
    private ScrollRect scrollRect;

    /// The last position where the user has dragged.
    private Vector2 lastDragPosition;

    /// Is the user dragging in the positive axis or the negative axis?
    private bool positiveDrag;

    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        lastDragPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        positiveDrag = eventData.position.y > lastDragPosition.y;
        lastDragPosition = eventData.position;
    }
    public void OnViewScroll()
    {
        HandleVerticalScroll();
    }

    private void HandleVerticalScroll()
    {
        int currItemIndex = positiveDrag ? scrollRect.content.childCount - 1 : 0;
        var currItem = scrollRect.content.GetChild(currItemIndex);

        if (!ReachedThreshold(currItem))
        {
            return;
        }

        int endItemIndex = positiveDrag ? 0 : scrollRect.content.childCount - 1;
        Transform endItem = scrollRect.content.GetChild(endItemIndex);
        Vector2 newPos = endItem.position;

        if (positiveDrag)
        {
            newPos.y = endItem.position.y - scrollContent.ChildHeight * 1.5f;
        }
        else
        {
            newPos.y = endItem.position.y + scrollContent.ChildHeight * 1.5f;
        }

        currItem.position = newPos;
        currItem.SetSiblingIndex(endItemIndex);
    }
    private bool ReachedThreshold(Transform item)
    {
        float posYThreshold = transform.position.y + scrollContent.Height * 0.5f;
        float negYThreshold = transform.position.y - scrollContent.Height * 0.5f;
        return positiveDrag ? item.position.y - scrollContent.ChildWidth * 0.5f > posYThreshold :
        item.position.y + scrollContent.ChildWidth * 0.5f < negYThreshold;
    }
}
