using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    ItemSlotManager itemSlotManager;
    MainManager mainManager;

    [Header("Objects")]
    public GameObject item_Parent;
    public GameObject item_Prefab;

    [Header("Sprites")]
    public Sprite Crate_1;
    public Sprite Crate_2;
    public Sprite Crate_3;
    public Sprite Crate_4;
    public Sprite Crate_5;
    public Sprite Crate_6;
    public Sprite Crate_NULL;

    [Header("Lists")]
    public List<GameObject> item_List;


    //--------------------


    private void Start()
    {
        itemSlotManager = FindObjectOfType<ItemSlotManager>();
        mainManager = FindObjectOfType<MainManager>();

    }


    //--------------------


    public void SnapBackToStartPosition(Transform transform, bool isConnected)
    {
        //Force all dice not connected to a ItemSlot, to move back to their starting position
        for (int i = 0; i < mainManager.crate_List.Count; i++)
        {
            if (!mainManager.crate_List[i].GetComponent<DragDrop>().isConnected)
            {
                mainManager.crate_List[i].transform.position = mainManager.itemSlot_List[i].transform.position;
            }
        }
    }
}
