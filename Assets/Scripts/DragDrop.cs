using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    MainManager mainManager;
    ItemSlotManager itemSlotManager;
    ItemManager itemManager;

    [SerializeField] Canvas canvas;

    RectTransform rectTransform;
    public CanvasGroup canvasGroup;

    public bool isConnected;
    public bool isDragging;


    //--------------------


    private void Awake()
    {
        mainManager = FindObjectOfType<MainManager>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        itemSlotManager = FindObjectOfType<ItemSlotManager>();

        //Find the canvas for DragDrop scaling
        if (GameObject.Find("MainCanvas") != null)
        {
            canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        }
    }


    //--------------------


    //When GameObject is pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.75f;
        canvasGroup.blocksRaycasts = false;
        mainManager.BlockRaycastFalse();

        isDragging = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        mainManager.BlockRaycastFalse();

        isDragging = false;
    }

    //Drag Handler
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        isDragging = true;
    }

    //When Dragging
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.75f;
        canvasGroup.blocksRaycasts = false;
        mainManager.BlockRaycastFalse();

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
        mainManager.BlockRaycastTrue();

        itemManager.SnapBackToStartPosition();

        isDragging = false;
    }
}
