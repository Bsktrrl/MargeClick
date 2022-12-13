using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    MainManager mainManager;
    ItemManager itemManager;

    public int itemValue;

    public Vector2 itemPosition;
    public int itemListPosition;

    //--------------------


    private void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        itemManager = FindObjectOfType<ItemManager>();

        //Assagn the correct value to the item
        itemValue = mainManager.itemValue;
    }

    private void Update()
    {
        //Assign the correct image to the item, based on its value
        ImageSprite();
    }


    //--------------------


    void ImageSprite()
    {
        if (itemValue == 1)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_1;
        else if (itemValue == 2)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_2;
        else if (itemValue == 3)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_3;
        else if (itemValue == 4)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_4;
        else if (itemValue == 5)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_5;
        else if (itemValue == 6)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_6;
        else
            gameObject.GetComponent<Image>().sprite = itemManager.Item_NULL;
    }
}
