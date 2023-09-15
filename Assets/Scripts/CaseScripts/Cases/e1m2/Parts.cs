using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parts : MonoBehaviour
{
    [SerializeField] GameObject colorHolder, counter;
    bool isPainted;

    public void ChangeColor()
    {
        if(!isPainted)
        {
            isPainted = true;
            counter.GetComponent<WinCaseE1M2>().SetCount();
        }
        GetComponent<Image>().color = colorHolder.GetComponent<CH>().GetColor();
    }
}
