using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    MainManager mainManager;
    ItemManager itemManager;

    public int itemTier;

    [SerializeField] Image bakcground;
    [SerializeField] Image tierImage;

    public Vector2 itemPosition;
    public int itemListPosition;


    //--------------------


    private void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        itemManager = FindObjectOfType<ItemManager>();
        
        //Assign Bakground image
        bakcground.sprite = itemManager.Item_Background;
    }

    private void Update()
    {
        //Assign the correct image to the item, based on its value
        ImageSprite();
    }


    //--------------------


    void ImageSprite()
    {
        //Item sprite change
        if (itemTier % 10 == 1)
            tierImage.sprite = itemManager.Item_1;
        else if (itemTier % 10 == 2)
            tierImage.sprite = itemManager.Item_2;
        else if (itemTier % 10 == 3)
            tierImage.sprite = itemManager.Item_3;
        else if (itemTier % 10 == 4)
            tierImage.sprite = itemManager.Item_4;
        else if (itemTier % 10 == 5)
            tierImage.sprite = itemManager.Item_5;
        else if (itemTier % 10 == 6)
            tierImage.sprite = itemManager.Item_6;
        else if (itemTier % 10 == 7)
            tierImage.sprite = itemManager.Item_7;
        else if (itemTier % 10 == 8)
            tierImage.sprite = itemManager.Item_8;
        else if (itemTier % 10 == 9)
            tierImage.sprite = itemManager.Item_9;
        else if (itemTier % 10 == 0)
            tierImage.sprite = itemManager.Item_10;
        else
            tierImage.sprite = itemManager.Item_NULL;

        //Item color change
        if (itemTier < 11)
            bakcground.color = new Color(1f, 1f, 1f, 1f);
        else if (itemTier < 21)
            bakcground.color = new Color(0.9f, 1f, 1f, 1f);
        else if (itemTier < 31)
            bakcground.color = new Color(0.8f, 1f, 1f, 1f);
        else if (itemTier < 41)
            bakcground.color = new Color(0.7f, 1f, 1f, 1f);
        else if (itemTier < 51)
            bakcground.color = new Color(0.6f, 1f, 1f, 1f);
        else if (itemTier < 61)
            bakcground.color = new Color(0.5f, 1f, 1f, 1f);
        else if (itemTier < 71)
            bakcground.color = new Color(0.4f, 1f, 1f, 1f);
        else if (itemTier < 81)
            bakcground.color = new Color(0.3f, 1f, 1f, 1f);
        else if (itemTier < 91)
            bakcground.color = new Color(0.2f, 1f, 1f, 1f);
        else if (itemTier < 101)
            bakcground.color = new Color(0.1f, 1f, 1f, 1f);
        else if (itemTier < 111)
            bakcground.color = new Color(0f, 0f, 0f, 1f);
    }
}
