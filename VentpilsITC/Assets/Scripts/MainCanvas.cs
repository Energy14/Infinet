using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    public RectTransform dragIcon;
    public DragObject dragPrefab;

    public GameObject firstSlot;
    public GameObject secondSlot;

    public GameObject resultObj;

    private bool firstSlotTaken = false;
    private bool secondSlotTaken = false;

    private Image firstSlotImage;
    private Image secondSlotImage;

    public Transform content;
    private DropObject mergeArea;
    private DragObject currentDrag;

    private void Start()
    {
        firstSlotImage = firstSlot.GetComponent<Image>();
        secondSlotImage = secondSlot.GetComponent<Image>();
    }

    public void OnBeginDrag(DragObject target)
    {
        currentDrag = target;
        Image icon = dragIcon.GetComponent<Image>();
        icon.sprite = currentDrag.image.sprite;
        dragIcon.gameObject.SetActive(true);
    }
    public void OnEndDrag()
    {
        currentDrag = null;
        dragIcon.gameObject.SetActive(false);
    }
    public void OnDrag()
    {
        dragIcon.position = Input.mousePosition;
    }
    public void OnDrop(DropObject target)
    {
        if (firstSlotTaken == false)
        {
            firstSlot.SetActive(true);
            firstSlotTaken = true;
            target.itemName = currentDrag.itemName;
            firstSlotImage.sprite = currentDrag.image.sprite;
            GameManager.instance.AddItem(currentDrag.itemName);
        } else if (secondSlotTaken == false)
        {
            secondSlot.SetActive(true);
            secondSlotTaken = true;
            target.itemName = currentDrag.itemName;
            secondSlotImage.sprite = currentDrag.image.sprite;
            GameManager.instance.AddItem(currentDrag.itemName);
        }
    }
    public void OnCollectButton()
    {
        GameManager.instance.buttonCollect.SetActive(false);

        DragObject obj = Instantiate(dragPrefab, content);

        resultObj.SetActive(false);
        obj.image.sprite = GameManager.instance.resultObject.image.sprite;
        obj.txt.text = GameManager.instance.resultObject.itemName;
        obj.itemName = GameManager.instance.resultObject.itemName;
        GameManager.instance.clearRecipe();
    }
    public void clearSlots()
    {
        firstSlotTaken = false;
        secondSlotTaken = false;
    }
    public void disableSlots()
    {
        firstSlot.SetActive(false);
        secondSlot.SetActive(false);
    }
}
