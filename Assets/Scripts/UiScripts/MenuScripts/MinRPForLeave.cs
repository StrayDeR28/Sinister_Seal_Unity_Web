using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinRPForLeave : MonoBehaviour
{
    public void SetPlayerPrefsForRP()//если вышли на карту из кейса - запомнили этот кейс (только один)
    {
        PlayerPrefs.SetInt("CaseLeft", int.Parse(PlayerPrefs.GetString("levelIndex")));
    }
}
