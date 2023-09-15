using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class E1M4Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            if (eventData.pointerDrag.GetComponent<E1M4Drag>() == true)
            {
                var oldElementTransform = transform.GetChild(0);//смена строк
                oldElementTransform.SetParent(eventData.pointerDrag.GetComponent<E1M4Drag>().GetTransform());
                oldElementTransform.localPosition = Vector3.zero;

                var newElementTransform = eventData.pointerDrag.transform;
                newElementTransform.SetParent(transform);
                newElementTransform.localPosition = Vector3.zero;
            }
        }
    }
}
