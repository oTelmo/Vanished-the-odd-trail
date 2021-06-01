using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<int> currentItemsID;
    public bool inventoryOpen = false;
    public int arrowCount = 5;

    public GameObject currentItem;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            arrowCount++;
        }
    }
}
