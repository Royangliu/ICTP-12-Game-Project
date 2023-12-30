using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SquisherScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool canRep = true;
    [SerializeField] GameObject squeezer;
    [SerializeField] Transform top;
    [SerializeField] Transform bottom;

    private float differenceInY;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= top.position.y - 25)
        {
            canRep = true;
        }
        if (canRep && transform.position.y <= bottom.position.y + 5 && squeezer.GetComponent<SqueezerScript>().hasItemToMake)
        {
            squeezer.GetComponent<SqueezerScript>().reps++;
            FindObjectOfType<AudioManager>().Play("Squish");
            canRep = false;
        }
    }

    // Drag and Drop
    public void OnBeginDrag(PointerEventData eventData)
    {
        squeezer.GetComponent<SqueezerScript>().reps = 0;
        canRep = true;
        differenceInY = transform.position.y - Input.mousePosition.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 temp = Input.mousePosition;
        temp.y = Input.mousePosition.y + differenceInY;
        temp.x = transform.position.x;

        if (temp.y <= top.position.y && temp.y >= bottom.position.y)
        {
            transform.position = temp;
        }
        else if (temp.y < bottom.position.y)
        {
            transform.position = bottom.position;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = top.position;
    }
}
