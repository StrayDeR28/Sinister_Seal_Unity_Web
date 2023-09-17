using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPrefs : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetString("Condition:rune", "blank");// Для текущего условия не должно быть пустым, задавать при старте игры
    }
}
