using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item System/Item/Flashlight")]
public class FlashlightScriptable : Item
{
    private GameObject hand;

    public override void UseItem(Character character)
    {
        /*hand = GameObject.FindWithTag("Hand");
        hand.transform.GetChild(2).gameObject.SetActive(true);*/
    }
}
