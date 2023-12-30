using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutFruit : MonoBehaviour
{
    private GameObject child;

    [SerializeField] GameObject button;
    [SerializeField] GameObject slot;

    [SerializeField] int cutThreshold = 5;
    [HideInInspector] public int clickCount = 0;

    private bool isActive = false;

    [SerializeField] List<Item> cuttableItems = new List<Item>();
    [SerializeField] List<Item> cutItems = new List<Item>();


    private void Start()
    {
        if (UpgradeVariables.upgradeStations)
        {
            cutThreshold = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (slot.transform.childCount > 0)
        {
            child = slot.transform.GetChild(0).gameObject;
            Item childItem = child.GetComponent<InventoryItem>().item;
            int itemIndex = cuttableItems.IndexOf(childItem);
            if (itemIndex != -1)
            {
                if (isActive == false)
                {
                    button.SetActive(true);
                    isActive = true;
                }
                if (clickCount == cutThreshold)
                {
                    child.GetComponent<InventoryItem>().InitializeItem(cutItems[itemIndex]);
                    button.SetActive(false);
                    isActive = false;
                }
            } 
        }
        else
        {
            button.SetActive(false);
            clickCount = 0;
            isActive = false;
        }
    }

    public void addCut()
    {
        clickCount++;
        FindObjectOfType<AudioManager>().Play("Chop");
    }
}
