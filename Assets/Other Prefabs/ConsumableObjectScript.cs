using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumableObjectScript : MonoBehaviour
{
    [SerializeField] Image image;
    [HideInInspector] public Item itemToGive;
    [HideInInspector] public GameObject inventoryManager;

    public void initializeConsumableObject()
    {
        image.sprite = itemToGive.image;
        gameObject.SetActive(true);
    }

    public void addItemToInventory()
    {
        inventoryManager.GetComponent<InventoryManager>().AddItem(itemToGive);
        Destroy(gameObject);
    }
}