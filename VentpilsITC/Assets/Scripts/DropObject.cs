using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropObject : MonoBehaviour
{
    public Image image;
    private MainCanvas canvas;

    public Sprite sprite
    {
        set
        {
            image.sprite = value;
        }
    }
    private void Awake()
    {
        canvas = GetComponentInParent<MainCanvas>();
    }

    public void OnDrop(BaseEventData bases)
    {
        canvas.OnDrop(this);
    }
}
