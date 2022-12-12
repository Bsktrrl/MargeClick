using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    MainManager mainManager;
    ItemManager itemManager;

    [SerializeField] int itemValue;

    //--------------------


    private void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        itemManager = FindObjectOfType<ItemManager>();

        //Assign the correct image to the item
        ImageSprite();

        //Assagn the correct value to the item
        itemValue = mainManager.itemValue;
    }


    //--------------------


    void ImageSprite()
    {
        if (mainManager.itemValue == 1)
            gameObject.GetComponent<Image>().sprite = itemManager.Crate_1;
        else if (mainManager.itemValue == 2)
            gameObject.GetComponent<Image>().sprite = itemManager.Crate_2;
        else if (mainManager.itemValue == 3)
            gameObject.GetComponent<Image>().sprite = itemManager.Crate_3;
        else if (mainManager.itemValue == 4)
            gameObject.GetComponent<Image>().sprite = itemManager.Crate_4;
        else if (mainManager.itemValue == 5)
            gameObject.GetComponent<Image>().sprite = itemManager.Crate_5;
        else if (mainManager.itemValue == 6)
            gameObject.GetComponent<Image>().sprite = itemManager.Crate_6;
        else
            gameObject.GetComponent<Image>().sprite = itemManager.Crate_NULL;
    }
}
