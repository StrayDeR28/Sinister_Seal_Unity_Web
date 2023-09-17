using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum ItemType
    {
        Water,
        Alcohol,
        Glycerin,

        Valerian,
        Lavender,
        Burnet,
        Acacia,

        PotassiumPermanganate,
        Sugar,
        Chromium
    }

    public enum IngredientType
    {
        Base,
        Herb,
        Chemical
    }

    public ItemSO itemSO;
    public uint amount;
    public Item copy;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begindrag");

        if (transform.parent.gameObject?.GetComponent<Slot>() == null)
        {
            copy = Instantiate(this, transform.parent);
            transform.parent.SetAsLastSibling();
        }
        else { copy = this; }

        copy.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        copy.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // if (eventData.pointerCurrentRaycast.gameObject?.GetComponent<Slot>() == null)
        if (eventData.pointerEnter?.GetComponent<Slot>() == null)
        {
            Debug.Log("enddrag");
            Destroy(copy.gameObject);
        }

        // if(eventData.pointerEnter.GetComponent<Item>() != null && eventData.pointerEnter.transform.parent.GetComponent<Slot>() != null)
        // {
        //     eventData.pointerEnter = eventData.pointerDrag;
        // }

        copy.GetComponent<Image>().raycastTarget = true;
    }
}
