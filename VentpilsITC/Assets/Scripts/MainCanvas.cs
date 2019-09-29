using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    public RectTransform dragIcon;
    private DragObject currentDrag;

    public void OnBeginDrag(DragObject target)
    {
        Debug.Log("Begin");
        currentDrag = target;
        Image icon = dragIcon.GetComponent<Image>();
        icon.sprite = currentDrag.image.sprite;
        dragIcon.gameObject.SetActive(true);
    }
    public void OnEndDrag()
    {
        Debug.Log("End");
        currentDrag = null;
        dragIcon.gameObject.SetActive(false);
    }
    public void OnDrag()
    {
        dragIcon.position = Input.mousePosition;
    }
    public void OnDrop(DropObject target)
    {
        target.sprite = currentDrag.image.sprite;
        Debug.Log("Drop here");
    }
}
