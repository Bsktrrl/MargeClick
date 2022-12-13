using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    MainManager mainManager;
    ItemSlotManager itemSlotManager;
    ItemManager itemManager;
    Item item;

    public bool hasItem;


    //--------------------


    private void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        itemSlotManager = FindObjectOfType<ItemSlotManager>();
        itemManager = FindObjectOfType<ItemManager>();
        item = FindObjectOfType<Item>();
    }

    //When dropped on
    public void OnDrop(PointerEventData eventData)
    {
        mainManager.BlockRaycastTrue();

        if (eventData.pointerDrag != null && !eventData.pointerDrag.GetComponent<DragDrop>().isConnected && !hasItem)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().isConnected = true;
            itemSlotManager.isOccupied = true;

            eventData.pointerDrag.GetComponent<DragDrop>().transform.position = gameObject.transform.position;
        }
        else if (eventData.pointerDrag != null && !eventData.pointerDrag.GetComponent<DragDrop>().isConnected && hasItem)
        {
            //Check the position of all slots, to see if it matches with an item
            for (int i = 0; i < itemManager.item_List.Count; i++)
            {
                if (gameObject.transform.position == itemManager.item_List[i].transform.position)
                {
                    //If it matches with an item, check if that item has the same value as the moved item
                    if (itemManager.item_List[i].GetComponent<Item>().itemValue == eventData.pointerDrag.GetComponent<Item>().itemValue)
                    {
                        //Prepare all items higher in item_List for this item's removal, by decreasing their element position
                        for (int j = 0; j < itemManager.item_List.Count; j++)
                        {
                            if (itemManager.item_List[j].GetComponent<Item>().itemListPosition > eventData.pointerDrag.GetComponent<Item>().itemListPosition)
                            {
                                itemManager.item_List[j].GetComponent<Item>().itemListPosition -= 1;
                            }
                        }
                        
                        itemManager.item_List[i].GetComponent<Item>().itemValue += 1;

                        //If there is a value-match, destroy the moved item and increase the value of the item on this slot
                        itemManager.item_List.RemoveAt(eventData.pointerDrag.GetComponent<Item>().itemListPosition);
                        Destroy(eventData.pointerDrag);

                        return;
                    }
                }
            }
        }
    }
}
