using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderMaker : MonoBehaviour
{
    public List<InventorySlot> playerInventorySlots;

    [SerializeField] List<Item> possibleOrders;
    private Item chosenOrder;

    [SerializeField] GameObject orderTimer;
    [SerializeField] GameObject orderImage;
    [SerializeField] GameObject orderBackground;


    // initializes the children of the customer
    public void makeOrder()
    {
        chosenOrder = possibleOrders[Random.Range(0, possibleOrders.Count)];
        orderImage.GetComponent<SpriteRenderer>().sprite = chosenOrder.image;

        orderBackground.SetActive(true);
        orderTimer.SetActive(true);
        orderImage.SetActive(true);
    }

    public bool canSell()
    {
        foreach (InventorySlot currentSlot in playerInventorySlots)
        {
            if (currentSlot.transform.childCount > 0)
            {
                Item itemInSlot = currentSlot.transform.GetChild(0).gameObject.GetComponent<InventoryItem>().item;
                if (itemInSlot == chosenOrder)
                {
                    Destroy(currentSlot.transform.GetChild(0).gameObject);
                    return true;
                }
            }
        }
        return false;
    }

    public void destroyOrder()
    {
        orderTimer.SetActive(false);
        orderImage.SetActive(false);
        orderBackground.SetActive(false);
    }
}
