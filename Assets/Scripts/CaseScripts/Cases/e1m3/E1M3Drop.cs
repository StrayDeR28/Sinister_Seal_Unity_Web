using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class E1M3Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private int blockNumber;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<E1M3Drag>() != null)
        {
            if (transform.childCount == 0 && eventData.pointerDrag.GetComponent<E1M3Drag>().GetBlockNumber() == blockNumber)
            {
                eventData.pointerDrag.transform.SetParent(transform);
            }
        }
        
    }
}
