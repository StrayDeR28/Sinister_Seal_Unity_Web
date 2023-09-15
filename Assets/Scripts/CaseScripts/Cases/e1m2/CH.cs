using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CH : MonoBehaviour
{
    [SerializeField] Color color;

    public void SetColor(Color _color)
    {
        color = _color;
        color.a = 1f;
    }
    public Color GetColor()
    {
        return color;
    }
}
