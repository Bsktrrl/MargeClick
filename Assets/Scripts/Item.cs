using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    MainManager mainManager;
    ItemManager itemManager;

    public int itemTier;

    public Vector2 itemPosition;
    public int itemListPosition;


    //--------------------


    private void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        itemManager = FindObjectOfType<ItemManager>();

        //Assagn the correct value to the item
        itemTier = mainManager.itemTier_Current;
    }

    private void Update()
    {
        //Assign the correct image to the item, based on its value
        ImageSprite();
    }


    //--------------------


    void ImageSprite()
    {
        if (itemTier == 1)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_1;
        else if (itemTier == 2)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_2;
        else if (itemTier == 3)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_3;
        else if (itemTier == 4)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_4;
        else if (itemTier == 5)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_5;
        else if (itemTier == 6)
            gameObject.GetComponent<Image>().sprite = itemManager.Item_6;
        else
            gameObject.GetComponent<Image>().sprite = itemManager.Item_NULL;
    }
}
