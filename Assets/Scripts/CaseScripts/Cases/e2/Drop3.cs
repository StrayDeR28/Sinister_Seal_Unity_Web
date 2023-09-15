using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop3 : MonoBehaviour, IDropHandler
{
    [SerializeField] int index;
    [SerializeField] GameObject counter;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.GetComponent<Drag>().GetIndex() == index)
        {
            eventData.pointerClick.GetComponent<ButtonClickSound>().PlayClickSound();
            transform.Find(eventData.pointerDrag.name).gameObject.SetActive(true);
            Destroy(eventData.pointerDrag);
            //eventData.pointerDrag.SetActive(false);
            counter.GetComponent<WinCaseE2M3>().SetCount();
        }
    }
}
