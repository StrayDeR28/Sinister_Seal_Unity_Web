using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drop11 : MonoBehaviour, IDropHandler
{
    [SerializeField] int index;
    [SerializeField] GameObject counter;

    public void OnDrop(PointerEventData eventData)
    {
        if (index == eventData.pointerDrag.GetComponent<Drag11>().GetIndex())
        {
            GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
            Destroy(eventData.pointerDrag);
            gameObject.GetComponent<Image>().raycastTarget = false;
            Destroy(this);
            counter.GetComponent<WinCaseE1M1>().SetCount();
        }
    }
}
