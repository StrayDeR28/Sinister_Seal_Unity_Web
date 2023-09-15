using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag4 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    RectTransform rectTransform;
    Vector2 startPosition;
    CanvasGroup canvasGroup;
    [SerializeField] Canvas canvas;
    [SerializeField] int index, correctIndex;
    public bool flag;
    
    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();
        flag = index == correctIndex;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling();
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        if (rectTransform.anchoredPosition.x != 0)
        {
            rectTransform.anchoredPosition = new Vector2(0, rectTransform.anchoredPosition.y);
        }  
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = startPosition;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        flag = index == correctIndex;
    }

    public void OnDrop(PointerEventData eventData)
    {
        (eventData.pointerDrag.GetComponent<Image>().sprite, GetComponent<Image>().sprite) = 
        (GetComponent<Image>().sprite, eventData.pointerDrag.GetComponent<Image>().sprite);

        (index, eventData.pointerDrag.GetComponent<Drag4>().index) = (eventData.pointerDrag.GetComponent<Drag4>().index, index);

        flag = index == correctIndex;
    }

    public int GetIndex()
    {
        return index;
    }

}
