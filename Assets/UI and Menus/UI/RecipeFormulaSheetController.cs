using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecipeFormulaSheetController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool isOn = false;
    private Vector3 differenceInSpace;
    public void turnOnandOff()
    {
        if (isOn)
        {
            gameObject.SetActive(false);
            isOn = false;
        }
        else
        {
            gameObject.SetActive(true);
            isOn = true;
        }
    }

    // Drag and drop
    public void OnBeginDrag(PointerEventData eventData)
    {
        differenceInSpace = transform.position - Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + differenceInSpace;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
