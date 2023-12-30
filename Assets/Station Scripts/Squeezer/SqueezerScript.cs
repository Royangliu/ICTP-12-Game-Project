using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueezerScript : MonoBehaviour
{
    [SerializeField] InventorySlot slot;
    [SerializeField] Recipe[] recipes;
    [SerializeField] GameObject squisher;
    [SerializeField] GameObject consumableObjectPrefab;
    [SerializeField] GameObject inventoryManager;
    [SerializeField] Transform juicePlacement;

    public int reps = 0;
    [SerializeField] int repsThreshold = 5;

    private Item itemToMake;
    [HideInInspector] public bool hasItemToMake = false;


    private void Start()
    {
        if (UpgradeVariables.upgradeStations)
        {
            repsThreshold = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (reps >= repsThreshold && hasItemToMake)
        {
            GameObject newConsumableItem = Instantiate(consumableObjectPrefab, transform);
            newConsumableItem.transform.position = juicePlacement.position;
            newConsumableItem.GetComponent<ConsumableObjectScript>().inventoryManager = inventoryManager;
            newConsumableItem.GetComponent<ConsumableObjectScript>().itemToGive = itemToMake;
            newConsumableItem.GetComponent<ConsumableObjectScript>().initializeConsumableObject();
            hasItemToMake = false;
            slot.transform.parent.gameObject.SetActive(true);
            reps = 0;
        }
        else if (slot.transform.childCount > 0 && hasItemToMake == false)
        {
            Item ingredient = slot.transform.GetChild(0).gameObject.GetComponent<InventoryItem>().item;
            foreach (Recipe recipe in recipes)
            {
                if (recipe.craftingItems[0] == ingredient)
                {
                    itemToMake = recipe.product;
                    hasItemToMake = true;
                    Destroy(slot.transform.GetChild(0).gameObject);
                    slot.transform.parent.gameObject.SetActive(false);
                    return;
                }
            }
        }
    }
}
