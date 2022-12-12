using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    ItemSlotManager itemSlotManager;
    ItemManager itemManager;

    [SerializeField] Canvas canvas;

    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    public bool isConnected;

    public int itemValue;


    //--------------------


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        itemManager = GetComponent<ItemManager>();
    }
    private void Start()
    {
        itemSlotManager = FindObjectOfType<ItemSlotManager>();

        //Find the canvas for DragDrop scaling
        if (GameObject.Find("MainCanvas") != null)
        {
            canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        }
    }


    //--------------------


    


    //--------------------


    //When GameObject is pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.75f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    //Drag Handler
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //When Dragging
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.75f;
        canvasGroup.blocksRaycasts = false;

        if (isConnected)
        {
            itemSlotManager.isOccupied = false;
            isConnected = false;
        }
    }

    //When Not Dragging
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        itemManager.SnapBackToStartPosition(gameObject.transform, isConnected);
    }
}
