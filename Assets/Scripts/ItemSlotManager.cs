using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour
{
    ItemManager itemManager;
    MainManager mainManager;

    public bool isOccupied;


    //--------------------


    private void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        mainManager = FindObjectOfType<MainManager>();
    }
    private void Update()
    {
        UpdateConnections();
    }


    //-------------------- Update


    void UpdateConnections()
    {
        //Regulate itemSlot.hasItem 
        for (int i = 0; i < mainManager.itemSlot_List.Count; i++)
        {
            //If items are occuping a slot
            int itemCount = 0;
            for (int j = 0; j < itemManager.item_List.Count; j++)
            {
                if (mainManager.itemSlot_List[i].transform.position == itemManager.item_List[j].transform.position)
                {
                    mainManager.itemSlot_List[i].GetComponent<ItemSlot>().hasItem = true;

                    j = itemManager.item_List.Count;
                }
                else
                {
                    itemCount++;
                }
            }

            //If crates are occuping a slot
            int crateCount = 0;
            for (int k = 0; k < mainManager.crate_List.Count; k++)
            {
                if (mainManager.itemSlot_List[i].transform.position == mainManager.crate_List[k].transform.position)
                {
                    mainManager.itemSlot_List[i].GetComponent<ItemSlot>().hasItem = true;

                    k = mainManager.crate_List.Count;
                }
                else
                {
                    crateCount++;
                }
            }

            //Turn "hasItem = false" if there are none items/crates on the Slot
            if (itemCount >= itemManager.item_List.Count && crateCount >= mainManager.crate_List.Count)
            {
                mainManager.itemSlot_List[i].GetComponent<ItemSlot>().hasItem = false;
            }
        }
    }
}
