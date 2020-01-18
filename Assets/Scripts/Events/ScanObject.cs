using UnityEngine;
using System.Collections;

public class ScanObject : MonoBehaviour
{
    public Item item;

    private Color mouseOverColor;
    private Color startColor;
    private bool mouseOver = false;

    void Start()
    {
        startColor = GetComponent<Renderer>().material.GetColor("_Color");
        SetMouseOverColor();
    }

    void SetMouseOverColor()
    {
        if (item.isScanned)
        {
            mouseOverColor = Color.green;
        } else
        {
            mouseOverColor = Color.red;
        }
    }

    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        mouseOver = true;
        SetColorOnObject(mouseOverColor);
    }

    void SetColorOnObject(Color color)
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Scan();
        }
    }

    void Scan()
    {
        // only allow scanned item once
        if (item.isScanned) return;
        item.isScanned = true;
        Inventory.instance.Scan(item);
        SetMouseOverColor();
        SetColorOnObject(mouseOverColor);
    }

    void OnMouseExit()
    {
        mouseOver = false;
        SetColorOnObject(startColor);
    }

}