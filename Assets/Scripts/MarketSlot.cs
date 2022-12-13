using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MarketSlot : MonoBehaviour, IDropHandler
{
    MainManager mainManager;
    ItemManager itemManager;


    //--------------------


    private void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        itemManager = FindObjectOfType<ItemManager>();
    }


    //--------------------


    public void OnDrop(PointerEventData eventData)
    {
        mainManager.BlockRaycastTrue();

        if (eventData.pointerDrag != null && !eventData.pointerDrag.GetComponent<DragDrop>().isConnected)
        {
            //Increase SalePoints
            mainManager.salePoints += eventData.pointerDrag.GetComponent<Item>().itemTier * 2;

            //Prepare all items higher in item_List for this item's removal, by decreasing their element position
            for (int j = 0; j < itemManager.item_List.Count; j++)
            {
                if (itemManager.item_List[j].GetComponent<Item>().itemListPosition > eventData.pointerDrag.GetComponent<Item>().itemListPosition)
                {
                    itemManager.item_List[j].GetComponent<Item>().itemListPosition -= 1;
                }
            }

            //Destroy item
            itemManager.item_List.RemoveAt(eventData.pointerDrag.GetComponent<Item>().itemListPosition);
            Destroy(eventData.pointerDrag);

            return;
        }
    }
}
