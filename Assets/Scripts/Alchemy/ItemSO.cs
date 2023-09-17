using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/New ItemSO")]
public class ItemSO : ScriptableObject
{
    public Item.ItemType itemType;
    public Item.IngredientType ingredientType;
    public string itemName;
    public Sprite itemSprite;
}
