using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    ItemSlotManager itemSlotManager;

    public bool hasItem;


    //--------------------


    private void Start()
    {
        itemSlotManager = FindObjectOfType<ItemSlotManager>();
    }

    //When dropped on
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && !eventData.pointerDrag.GetComponent<DragDrop>().isConnected)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().isConnected = true;
            itemSlotManager.isOccupied = true;

            eventData.pointerDrag.GetComponent<DragDrop>().transform.position = gameObject.transform.position;
        }
    }
}
