using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Stopwatch : MonoBehaviour
{   
    bool useOnceflag = true;
    float currentTime = 0;
    [SerializeField] private TMP_Text currentTimeText;
    [SerializeField] GameObject pepasanObject;

    private void Awake()
    {
        StartStopwatch();
    }
    public IEnumerator RunStopwatch()
    {   
        while (true)
        {
            yield return new WaitForSeconds(0);
            currentTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.ToString(@"mm\:ss");
            if (useOnceflag == true && currentTime >= 120.0 )//время, через которое свинка начинает подгонять игрока
            {
                pepasanObject.GetComponent<PeposanAnimation>().ShowPepasan("stopwatch");
                useOnceflag = false;
            }
        }
    }
    public void StartStopwatch()
    {
        StartCoroutine("RunStopwatch");
    }
    public void StopStopwatch()
    {
        StopAllCoroutines();
    }
    public float GetCurrentTime()//обращаемся к этому при запросе времени для бека
    {
        return currentTime;
    }
}
