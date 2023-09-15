using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class E6M4Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            var oldElementTransform = transform.GetChild(0);//смена строк
            oldElementTransform.SetParent(eventData.pointerDrag.GetComponent<E6M4Drag>().GetTransform());
            oldElementTransform.localPosition = Vector3.zero;

            var newElementTransform = eventData.pointerDrag.transform;
            newElementTransform.SetParent(transform);
            newElementTransform.localPosition = Vector3.zero;
        }
/*        Color color = gameObject.GetComponent<Image>().color;
        color.a = 1f;
        gameObject.GetComponent<Image>().color = color;*/
    }
}