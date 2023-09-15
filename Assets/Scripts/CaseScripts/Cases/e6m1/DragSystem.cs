using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSystem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private int pieceNumber;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Color color = gameObject.GetComponent<Image>().color;
        color.a = 0.6f;
        gameObject.GetComponent<Image>().color=color;
        gameObject.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Color color = gameObject.GetComponent<Image>().color;
        color.a = 1f;
        gameObject.GetComponent<Image>().color = color;
        gameObject.GetComponent<Image>().raycastTarget = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }
    public int GetPieceNumber()
    {
        return pieceNumber;
    }
}
