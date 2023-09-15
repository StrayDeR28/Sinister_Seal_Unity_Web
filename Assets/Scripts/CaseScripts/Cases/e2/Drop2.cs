using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop2 : MonoBehaviour, IDropHandler
{
    [SerializeField] int index;
    [SerializeField] GameObject counter;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.GetComponent<Drag>().GetIndex() == index)
        {
            eventData.pointerClick.GetComponent<ButtonClickSound>().PlayClickSound();
            Destroy(eventData.pointerDrag);
            counter.GetComponent<WinCaseE2M2>().SetCount();
        }
    }
}
