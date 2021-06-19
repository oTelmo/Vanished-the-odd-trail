using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Item : ScriptableObject
{
    public int Id;
    public Sprite icon;
    public GameObject prefab;

    [SerializeField]
    protected int maxPerInventorySlot;

    public abstract void UseItem(PlayerInventory character);

    public Sprite GetIcon()
    {
        return icon;
    }

    public int GetMaxPerInventory()
    {
        return maxPerInventorySlot;
    }
}


