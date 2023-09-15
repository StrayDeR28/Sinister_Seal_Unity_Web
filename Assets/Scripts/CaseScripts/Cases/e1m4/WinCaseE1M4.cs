using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE1M4 : MonoBehaviour
{   
    [SerializeField] private GameObject grid;
    [SerializeField] private List<GameObject> elementsPosition1;
    [SerializeField] private List<GameObject> elementsPosition2;
    [SerializeField] GameObject WrongAnswerText;
    public void CheckParts()
    {
        var gridTransform = grid.GetComponent<Transform>();
        bool checkCondition = false;
        for (int i = 0; i < gridTransform.childCount; i++) 
        {
            if (gridTransform.GetChild(i).GetChild(0) != elementsPosition1[i].transform)
            {
                checkCondition = false;
                print(checkCondition);
                break;
            }
            else
            {
                checkCondition = true;
                print(checkCondition);
            }
        }
        if (checkCondition == false)
        {
            for (int i = 0; i < gridTransform.childCount; i++)//от 7 т.к. первый ребенок - это задний фон
            {
                if (gridTransform.GetChild(i).GetChild(0) != elementsPosition2[i].transform)
                {
                    checkCondition = false;
                    print(checkCondition);
                    break;
                }
                else
                {
                    checkCondition = true;
                    print(checkCondition);
                }
            }
        }
        if (checkCondition == true)
        {
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
        else
        {
            SetTrueWrongAnswer();
            Invoke("SetFalseWrongAnswer",5f);
        }
    }
    void SetTrueWrongAnswer() 
    {
        WrongAnswerText.SetActive(true); 
    }
    void SetFalseWrongAnswer() 
    {
        WrongAnswerText.SetActive(false); 
    }
}
