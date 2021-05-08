using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item System/Item/Bow & Arrow")]
public class BowScriptable : Item
{
    private GameObject hand;
    private GameObject[] usableItems;

    public override void UseItem(Character character)
    {
        Debug.Log(Id);
        //bow = Instantiate(prefab, character.transform.Find("Main Camera/Hand"));
        /*hand = GameObject.FindWithTag("Hand");
        hand.transform.GetChild(0).gameObject.SetActive(true);*/
    }
}
