using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Palette1 : MonoBehaviour
{
    [SerializeField] GameObject colorHolder;
    [SerializeField] Color color;

    public void Awake()
    {
        color = GetComponent<Image>().color;
    }

    public void ChooseColor()
    {
        colorHolder.GetComponent<CH>().SetColor(color);
    }
}
