using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<int> currentItemsID;
    public bool inventoryOpen = false;

    public GameObject currentItem;

    public float arrowCount = 5;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentItem.activeSelf)
            {
                currentItem.gameObject.SetActive(false);
            }
            else
            {
                currentItem.gameObject.SetActive(true);
            }
        }
    }
}
