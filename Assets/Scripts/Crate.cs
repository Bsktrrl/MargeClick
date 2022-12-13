using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    ItemManager itemManager;
    MainManager mainManager;
    CrateManager crateManager;

    public int crateListPosition;
    public int crateTier;


    //--------------------


    private void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        mainManager = FindObjectOfType<MainManager>();
        crateManager = FindObjectOfType<CrateManager>();
    }
    private void Update()
    {
        if (crateTier == 1)
            gameObject.GetComponent<Image>().sprite = crateManager.Crate_1;
        else if (crateTier == 2)
            gameObject.GetComponent<Image>().sprite = crateManager.Crate_2;
        else if (crateTier == 3)
            gameObject.GetComponent<Image>().sprite = crateManager.Crate_3;
    }


    //--------------------


    public void Crate_OnClick()
    {
        //Instantiate Item
        InstantiateItem();

        //Prepare all items higher in crate_List for this cate's removal, by decreasing their element position
        for (int i = 0; i < mainManager.crate_List.Count; i++)
        {
            if (mainManager.crate_List[i].GetComponent<Crate>().crateListPosition > gameObject.GetComponent<Crate>().crateListPosition)
            {
                mainManager.crate_List[i].GetComponent<Crate>().crateListPosition -= 1;
            }
        }

        //Destroy this gameobject
        mainManager.crate_List.RemoveAt(crateListPosition);
        Destroy(gameObject);
    }

    void InstantiateItem()
    {
        itemManager.item_List.Add(Instantiate(itemManager.item_Prefab, Vector3.zero, Quaternion.identity) as GameObject);
        itemManager.item_List[itemManager.item_List.Count - 1].transform.parent = itemManager.item_Parent.transform;

        itemManager.item_List[itemManager.item_List.Count - 1].transform.position = gameObject.transform.position;
        
        itemManager.item_List[itemManager.item_List.Count - 1].GetComponent<Item>().itemPosition = gameObject.transform.position;
        itemManager.item_List[itemManager.item_List.Count - 1].GetComponent<Item>().itemListPosition = itemManager.item_List.Count - 1;
        itemManager.item_List[itemManager.item_List.Count - 1].name = ("Item " + itemManager.item_List.Count);

        if (crateTier == 1)
        {
            itemManager.item_List[itemManager.item_List.Count - 1].GetComponent<Item>().itemTier = mainManager.itemTier_Current;
        }
        else if (crateTier == 2)
        {
            int tierCount = Random.Range(1, 3);

            if (mainManager.itemTier_Current + tierCount <= mainManager.itemTier_Max)
            {
                itemManager.item_List[itemManager.item_List.Count - 1].GetComponent<Item>().itemTier = mainManager.itemTier_Current + tierCount;
            }
            else
            {
                itemManager.item_List[itemManager.item_List.Count - 1].GetComponent<Item>().itemTier = mainManager.itemTier_Max;
            }
        }
        else if (crateTier == 3)
        {
            if (mainManager.itemTier_Current + 10 <= mainManager.itemTier_Max)
            {
                itemManager.item_List[itemManager.item_List.Count - 1].GetComponent<Item>().itemTier = mainManager.itemTier_Current + 10;
            }
            else
            {
                itemManager.item_List[itemManager.item_List.Count - 1].GetComponent<Item>().itemTier = mainManager.itemTier_Max;
            }
        }

        print("Expand ItemList: " + itemManager.item_List.Count);
    }
}
