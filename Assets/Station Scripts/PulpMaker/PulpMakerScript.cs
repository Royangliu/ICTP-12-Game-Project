using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PulpMakerScript : MonoBehaviour
{
    [SerializeField] GameObject inventoryManager;
    [SerializeField] GameObject consumableObjectPrefab;
    [SerializeField] GameObject juicePlacement;

    [SerializeField] InventorySlot[] ingredientSlots;
    [SerializeField] Recipe[] recipes;

    [SerializeField] GameObject mashButton;
    [SerializeField] Slider slider;
    [SerializeField] float operatingTime = 3f;

    private bool isMashing = false;
    private Item itemToMake;
    private float time = 0f;
    private List<Item> ingredients = new List<Item>();


    private void Start()
    {
        if (UpgradeVariables.upgradeStations)
        {
            operatingTime = 1f;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (isMashing)
        {
            slider.maxValue = operatingTime;
            mashButton.SetActive(false);
            time += Time.deltaTime;
            FindObjectOfType<AudioManager>().Play("MachineHum");

            if (time > operatingTime)
            {
                GameObject newConsumableItem = Instantiate(consumableObjectPrefab, transform);
                newConsumableItem.transform.position = juicePlacement.transform.position;
                newConsumableItem.GetComponent<ConsumableObjectScript>().inventoryManager = inventoryManager;
                newConsumableItem.GetComponent<ConsumableObjectScript>().itemToGive = itemToMake;
                newConsumableItem.GetComponent<ConsumableObjectScript>().initializeConsumableObject();
                mashButton.SetActive(true);
                isMashing = false;
                time = 0f;
                FindObjectOfType<AudioManager>().Stop("MachineHum");
            }
            slider.value = time;
        }
    }

    /*
    private void createConsumableObject(Item item)
    {
        slider.maxValue = operatingTime;
        mashButton.SetActive(false);
        float time = 0f;
        while (time <= operatingTime)
        {
            slider.value = time;
        }
        GameObject newConsumableItem = Instantiate(consumableObjectPrefab, transform);
        newConsumableItem.transform.position = juicePlacement.transform.position;
        newConsumableItem.GetComponent<ConsumableObjectScript>().inventoryManager = inventoryManager;
        newConsumableItem.GetComponent<ConsumableObjectScript>().itemToGive = item;
        newConsumableItem.GetComponent<ConsumableObjectScript>().initializeConsumableObject();
        mashButton.SetActive(true);
    }
    */

    // checks if the ingredients provided fits a recipe and creates a consumableItem if so
    public void checkForRecipe()
    {
        List<Item> ingredients = new List<Item>();
        foreach (InventorySlot slot in ingredientSlots)
        {
            if (slot.transform.childCount > 0)
            {
                ingredients.Add(slot.transform.GetChild(0).gameObject.GetComponent<InventoryItem>().item);
            }
        }
        
        foreach (Recipe recipe in recipes)
        {
            if (areIngredientsARecipe(recipe.craftingItems, ingredients))
            {
                // createConsumableObject(recipe.product);
                itemToMake = recipe.product;
                isMashing = true;

                foreach (InventorySlot slot in ingredientSlots) // deletes children in slots
                {
                    if (slot.transform.childCount > 0)
                    {
                        Destroy(slot.transform.GetChild(0).gameObject);
                    }
                }
            }
        }
    }

    // checks if the ingredients provided fits a recipe
    private bool areIngredientsARecipe(List<Item> recipe, List<Item> ingredients)
    {
        if (recipe.Count == ingredients.Count)
        {
            for (int i = 0; i < recipe.Count; i++)
            {
                if (recipe[i] != ingredients[i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}
