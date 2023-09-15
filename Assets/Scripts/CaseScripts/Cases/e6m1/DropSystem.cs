using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSystem : MonoBehaviour, IDropHandler
{
    [SerializeField] private int pieceNumber;
    [SerializeField] private GameObject pieceCounter;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<DragSystem>().GetPieceNumber() == pieceNumber)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Destroy(eventData.pointerDrag.GetComponent("DragSystem"));
            Color color = gameObject.GetComponent<Image>().color;
            color.a = 1f;
            gameObject.GetComponent<Image>().color = color;
            pieceCounter.GetComponent<WinCaseE6M1>().SetPieceCounter();
        }
    }
}
