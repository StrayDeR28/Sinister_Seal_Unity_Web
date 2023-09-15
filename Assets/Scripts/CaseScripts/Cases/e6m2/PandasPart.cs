using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PandasPart : MonoBehaviour
{
    [SerializeField] private GameObject colorHolder;
    [SerializeField] private string rightColor;
    [SerializeField] private bool colorRight = false;

    private string colorName;
    public void ChangeColor()
    {
        colorName = colorHolder.GetComponent<ColorHolder>().GetColor();
        SwitchColor();
        colorRight = true;//проверка только на смену цвета
        /*if (colorName == rightColor)
        {
            colorRight = true;
        }
        else
        {
            colorRight = false;
        }*/
    }
    public void SwitchColor()
    {
        switch (colorName)
        {
            case "color1":
                gameObject.GetComponent<Image>().color = new Color32(50, 46, 47, 255);//заменить на цвет дизайнеров
                break;
            case "color2":
                gameObject.GetComponent<Image>().color = new Color32(104, 104, 104, 255);//заменить на цвет дизайнеров
                break;
            case "color3":
                gameObject.GetComponent<Image>().color = new Color32(239, 235, 234, 255);//заменить на цвет дизайнеров
                break;
            case "color4":
                gameObject.GetComponent<Image>().color = new Color32(204, 198, 200, 255);//заменить на цвет дизайнеров
                break;
            case "color5":
                gameObject.GetComponent<Image>().color = new Color32(174, 155, 161, 255);//заменить на цвет дизайнеров
                break;
            case "color6":
                gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);//заменить на цвет дизайнеров
                break;
            case "color7":
                gameObject.GetComponent<Image>().color = new Color32(197, 139, 188, 255);//заменить на цвет дизайнеров
                break;
            case "color8":
                gameObject.GetComponent<Image>().color = new Color32(255, 234, 146, 255);//заменить на цвет дизайнеров
                break;
            case "color9":
                gameObject.GetComponent<Image>().color = new Color32(222, 91, 91, 255);//заменить на цвет дизайнеров
                break;
            case "color10":
                gameObject.GetComponent<Image>().color = new Color32(88, 136, 255, 255);//заменить на цвет дизайнеров
                break;
            case "color11":
                gameObject.GetComponent<Image>().color = new Color32(144, 203, 61, 255);//заменить на цвет дизайнеров
                break;
            case "color12":
                gameObject.GetComponent<Image>().color = new Color32(255, 205, 84, 255);//заменить на цвет дизайнеров
                break;
        }
    } 
    public bool GetColorRight()//упрощено до проверки закрашенности
    {
        return colorRight;
    }
}
