using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item System/Item/Hatchet")]
public class HatchetScriptable : Item
{

    private GameObject hand;
    private ItemType typeOfItem;

    public override void UseItem(Character character)
    {
        Debug.Log(typeOfItem);
        typeOfItem = ItemType.Hatchet; 
    }
}
