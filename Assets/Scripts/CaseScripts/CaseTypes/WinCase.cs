using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCase : MonoBehaviour
{
    public void WinCasePlayerPrefs()
    {
        //здесь условия победы
        PlayerPrefs.SetString("caseDone", "done");
    }
}
