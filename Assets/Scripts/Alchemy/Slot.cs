using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    public ItemSO item;

    public void OnDrop(PointerEventData eventData)
    {
        //if(transform.childCount > 0) Destroy(transform.GetChild(0).gameObject);
        item = eventData.pointerDrag.GetComponent<Item>().itemSO;
        //GetComponent<Image>().color = eventData.pointerDrag.GetComponent<Image>().color;

        eventData.pointerDrag.GetComponent<Item>().copy.transform.SetParent(transform);
        eventData.pointerDrag.GetComponent<Item>().copy.transform.localPosition = Vector3.zero;

        Debug.Log("drop");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
