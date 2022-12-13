using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    ItemManager itemManager;

    [Header("Objects")]
    [SerializeField] GameObject itemSlot_Parent;
    [SerializeField] GameObject itemSlot_Prefab;

    [SerializeField] GameObject crate_Parent;
    [SerializeField] GameObject crate_Prefab;

    [SerializeField] TextMeshProUGUI spawnButtonText;

    [Header("Lists")]
    public List<GameObject> itemSlot_List;
    public List<GameObject> crate_List;

    [Header("Variables")]
    int itemSlot_Amount = 25;
    public int itemTier_Max = 6;
    public int itemTier_Current = 1;
    public int buttonValue_Max = 2;
    public int buttonValue_Current;


    //--------------------


    private void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();

        Instantiate();

        buttonValue_Current = buttonValue_Max;
    }
    private void Update()
    {
        DisplaySpawnButtonText();
    }


    //--------------------


    void Instantiate()
    {
        //Preperation
        itemSlot_List.Clear();
        itemSlot_List = new List<GameObject>();

        //Build itemSlot_List
        for (int i = 0; i < itemSlot_Amount; i++)
        {
            itemSlot_List.Add(Instantiate(itemSlot_Prefab, Vector3.zero, Quaternion.identity) as GameObject);
            itemSlot_List[i].transform.parent = itemSlot_Parent.transform;

            itemSlot_List[i].name = "ItemSlot " + i;
        }
    }

    public void BlockRaycastFalse()
    {
        for (int i = 0; i < itemManager.item_List.Count; i++)
        {
            itemManager.item_List[i].GetComponent<DragDrop>().canvasGroup.blocksRaycasts = false;
        }
    }
    public void BlockRaycastTrue()
    {
        for (int i = 0; i < itemManager.item_List.Count; i++)
        {
            itemManager.item_List[i].GetComponent<DragDrop>().canvasGroup.blocksRaycasts = true;
        }
    }


    //--------------------


    public void SpawnButton_OnClick()
    {
        //Don't let anything happen when pressing the button, if the board is full
        if ((crate_List.Count + itemManager.item_List.Count) >= 25) { return; }

        //Check if button has been pressed enough times to spawn a crate
        buttonValue_Current -= 1;
        if (buttonValue_Current < 0)
        {
            buttonValue_Current = buttonValue_Max;
        }
        else { return; }

        //spawn a Crate
        bool crateIsFound = false;
        while (!crateIsFound)
        {
            //Create a random number
            int random = Random.Range(0, 25);

            if (!itemSlot_List[random].GetComponent<ItemSlot>().hasItem)
            {
                //Mark this ItemSlot as taken
                itemSlot_List[random].GetComponent<ItemSlot>().hasItem = true;

                //Spawn Crate on this ItemSlot
                crate_List.Add(Instantiate(crate_Prefab, Vector3.zero, Quaternion.identity) as GameObject);
                crate_List[crate_List.Count - 1].transform.parent = crate_Parent.transform;
                crate_List[crate_List.Count - 1].transform.position = itemSlot_List[random].transform.position;

                crate_List[crate_List.Count - 1].GetComponent<Crate>().crateListPosition = crate_List.Count - 1;
                crate_List[crate_List.Count - 1].name = ("Crate " + crate_List.Count);

                crateIsFound = true;
            }
        }
    }
    void DisplaySpawnButtonText()
    {
        spawnButtonText.text = buttonValue_Current.ToString();
    }
}
