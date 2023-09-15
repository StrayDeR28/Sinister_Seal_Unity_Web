using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palatte : MonoBehaviour
{
    [SerializeField] private string color;
    [SerializeField] private GameObject colorHolder;
    public void ChooseColor()
    {
        colorHolder.GetComponent<ColorHolder>().SetColor(color);
    }
}
