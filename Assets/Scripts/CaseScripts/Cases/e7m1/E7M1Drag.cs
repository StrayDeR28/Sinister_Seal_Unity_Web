using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class E7M1Drag : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    Transform parentAfterDrag;
    private Transform rootTransfrom;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rootTransfrom = transform.root;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        Color color = gameObject.GetComponent<Image>().color;
        color.a = 0.6f;
        gameObject.GetComponent<Image>().color = color;
        gameObject.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.parent == rootTransfrom)
        {
            transform.SetParent(parentAfterDrag);
        }
        transform.localPosition = Vector3.zero;
        Color color = gameObject.GetComponent<Image>().color;
        color.a = 1f;
        gameObject.GetComponent<Image>().color = color;
        gameObject.GetComponent<Image>().raycastTarget = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}