using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    ItemSlotManager itemSlotManager;
    MainManager mainManager;
    Item item;

    [Header("Objects")]
    public GameObject item_Parent;
    public GameObject item_Prefab;

    [Header("Sprites")]
    public Sprite Item_Background;

    public Sprite Item_1;
    public Sprite Item_2;
    public Sprite Item_3;
    public Sprite Item_4;
    public Sprite Item_5;
    public Sprite Item_6;
    public Sprite Item_7;
    public Sprite Item_8;
    public Sprite Item_9;
    public Sprite Item_10;
    public Sprite Item_NULL;

    [Header("Lists")]
    public List<GameObject> item_List = new List<GameObject>();


    //--------------------


    private void Start()
    {
        itemSlotManager = FindObjectOfType<ItemSlotManager>();
        mainManager = FindObjectOfType<MainManager>();
        item = FindObjectOfType<Item>();
    }


    //--------------------


    public void SnapBackToStartPosition()
    {
        //Force all Items not connected to an ItemSlot, to move back to their starting position
        for (int i = 0; i < item_List.Count; i++)
        {
            if (!item_List[i].GetComponent<DragDrop>().isConnected)
            {
                item_List[i].GetComponent<DragDrop>().transform.position = item_List[i].GetComponent<Item>().itemPosition;
            }

            item_List[i].GetComponent<Item>().itemPosition = item_List[i].GetComponent<DragDrop>().transform.position;
        }
    }
}
