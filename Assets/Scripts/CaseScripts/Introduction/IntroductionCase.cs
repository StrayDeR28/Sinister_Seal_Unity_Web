using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionCase : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void StartCase()
    {
        Time.timeScale = 1.0f;
    }
}
