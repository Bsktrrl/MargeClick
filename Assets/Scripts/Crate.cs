using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    ItemManager itemManager;
    MainManager mainManager;

    public int listPosition;


    //--------------------


    private void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        mainManager = FindObjectOfType<MainManager>();
    }


    //--------------------


    public void Crate_OnClick()
    {
        //Preperation
        itemManager.item_List.Clear();
        itemManager.item_List = new List<GameObject>();

        //Instantiate Item
        InstantiateItem();

        //Destroy this gameobject
        //print("ListElement: " + listPosition);

        for (int i = 0; i < mainManager.crate_List.Count; i++)
        {
            if (mainManager.crate_List[i].GetComponent<Crate>().listPosition > gameObject.GetComponent<Crate>().listPosition)
            {
                mainManager.crate_List[i].GetComponent<Crate>().listPosition -= 1;
            }
        }

        mainManager.crate_List.RemoveAt(listPosition);
        Destroy(gameObject);
    }

    void InstantiateItem()
    {
        itemManager.item_List.Add(Instantiate(itemManager.item_Prefab, Vector3.zero, Quaternion.identity) as GameObject);
        itemManager.item_List[itemManager.item_List.Count - 1].transform.parent = itemManager.item_Parent.transform;

        itemManager.item_List[itemManager.item_List.Count - 1].transform.position = gameObject.transform.position;
    }
}
