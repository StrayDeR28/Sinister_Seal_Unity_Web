using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CaseManager : MonoBehaviour
{
    [SerializeField] private CaseListSO prefabList;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject winScrene;
    [SerializeField] private GameObject stopwatch;
    [SerializeField] private GameObject hints;

    private int caseNumber;

    private void Awake()
    {
        caseNumber = int.Parse(PlayerPrefs.GetString("levelIndex"));
        Instantiate(prefabList.cases[caseNumber], canvas.transform);
        StartCoroutine(WaitForCaseComplete());
        SendlevelIndextoHints();
    }
    public IEnumerator WaitForCaseComplete()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            if(PlayerPrefs.GetString("caseDone") == "done")//levelIndex
            {
                stopwatch.GetComponent<Stopwatch>().StopStopwatch();
                winScrene.GetComponent<CountRatingPoints>().TakeDifficultyLevel(caseNumber);
                winScrene.SetActive(true);
                //StopCoroutine(WaitForCaseComplete());
                StopAllCoroutines();
            }
        }
    }
    public void SendlevelIndextoHints()
    {
        hints.GetComponent<HintCounter>().TakeCurrentLevel(caseNumber);
    }
}
