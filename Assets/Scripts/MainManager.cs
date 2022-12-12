using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject itemSlot_Parent;
    [SerializeField] GameObject itemSlot_Prefab;

    [SerializeField] GameObject crate_Parent;
    [SerializeField] GameObject crate_Prefab;

    [Header("Lists")]
    public List<GameObject> itemSlot_List;
    public List<GameObject> crate_List;

    [Header("Variables")]
    int itemSlot_Amount = 25;
    public int itemValue = 1;


    //--------------------


    private void Start()
    {
        Instantiate();
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
        }
    }


    //--------------------


    public void SpawnButton_OnClick()
    {
        //Create and spawn a new crate
        int random = Random.Range(0, 25);

        if (crate_List.Count >= 25) { return; }

        if (!itemSlot_List[random].GetComponent<ItemSlot>().hasItem)
        {
            //Mark this ItemSlot as taken
            itemSlot_List[random].GetComponent<ItemSlot>().hasItem = true;

            //Spawn Crate on this ItemSlot
            crate_List.Add(Instantiate(crate_Prefab, Vector3.zero, Quaternion.identity) as GameObject);
            crate_List[crate_List.Count - 1].transform.parent = crate_Parent.transform;
            crate_List[crate_List.Count - 1].transform.position = itemSlot_List[random].transform.position;

            crate_List[crate_List.Count - 1].GetComponent<Crate>().listPosition = crate_List.Count - 1;
        }
        else
        {
            SpawnButton_OnClick();
        }
    }
}
