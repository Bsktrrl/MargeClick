using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour
{
    ItemManager itemManager;
    MainManager mainManager;

    [Header("Images")]
    [SerializeField] Image display_Image;

    public bool isOccupied;
    public int storedValueForDisplay;

    int count;


    //--------------------


    private void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        mainManager = FindObjectOfType<MainManager>();
    }
    private void Update()
    {
        UpdateConnections();

        UpdateDisplaySprite();
    }


    //-------------------- Update


    void UpdateDisplaySprite()
    {
        if (isOccupied)
        {
            if (storedValueForDisplay == 1)
                display_Image.sprite = itemManager.Crate_1;
            else if (storedValueForDisplay == 2)
                display_Image.sprite = itemManager.Crate_2;
            else
                display_Image.sprite = itemManager.Crate_3;
        }
        else
        {
            display_Image.sprite = itemManager.Crate_3;
        }
    }


    //--------------------


    public void StoreValue(int value)
    {
        storedValueForDisplay = value;
    }

    void UpdateConnections()
    {
        ////Regulate itemSlot.hasItem 
        //for (int i = 0; i < itemSlot_List.Count; i++)
        //{
        //    for (int j = 0; j < itemManager.Dice_List.Count; j++)
        //    {
        //        if (itemSlot_List[i].transform.position == itemManager.Dice_List[j].transform.position)
        //        {
        //            itemSlot_List[i].GetComponent<ItemSlot>().hasItem = true;

        //            j = itemManager.Dice_List.Count;
        //        }
        //        else
        //        {
        //            itemSlot_List[i].GetComponent<ItemSlot>().hasItem = false;
        //        }
        //    }
        //}

        ////Reset Values if the Dice isn't on the ItemSlot
        //for (int i = 0; i < itemSlot_List.Count; i++)
        //{
        //    if (!itemSlot_List[i].GetComponent<ItemSlot>().hasItem)
        //    {
        //        itemSlot_List[i].GetComponent<ItemSlot>().valueStored = 0;
        //    }
        //}

        ////Add Value to storedValue_List[] when the ItemSlot is occupied
        //for (int i = 0; i < storedValue_List.Count; i++)
        //{
        //    storedValue_List[i] = itemSlot_List[i].GetComponent<ItemSlot>().valueStored;
        //}
    }
}
