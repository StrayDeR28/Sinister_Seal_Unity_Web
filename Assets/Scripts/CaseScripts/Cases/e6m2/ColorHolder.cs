using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHolder : MonoBehaviour
{
    [SerializeField] private string color;
    public void SetColor(string _color)
    {
        color = _color;
    }
    public string GetColor()
    {
        return color;
    }
}
