using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Recipe")]
public class Recipe : ScriptableObject
{
    public List<Item> craftingItems = new List<Item>();
    public Item product;
}
