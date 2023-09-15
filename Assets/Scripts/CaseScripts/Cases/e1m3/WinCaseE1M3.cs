using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE1M3 : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private List<GameObject> contentPosition1;
    [SerializeField] private List<GameObject> contentPosition2;
    [SerializeField] GameObject WrongAnswerText;
    public void CheckСontentPosition()
    {
        var contentTransform = content.GetComponent<Transform>();
        bool checkCondition = false;
        for (int i = 7; i < contentTransform.childCount; i++)//от 7 т.к. первый ребенок - это задний фон
        {
            if (contentTransform.GetChild(i).childCount > 0)
            {
                if (contentTransform.GetChild(i).GetChild(0) != contentPosition1[i - 7].transform)
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
            else
            {
                checkCondition = false;
                print("no Child");
                break;
            }
        }
        if (checkCondition == false)
        {
            for (int i = 7; i < contentTransform.childCount; i++)//от 7 т.к. первый ребенок - это задний фон
            {
                if (contentTransform.GetChild(i).childCount > 0)
                {
                    if (contentTransform.GetChild(i).GetChild(0) != contentPosition2[i - 7].transform)
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
                else
                {
                    checkCondition = false;
                    print("no Child");
                    break;
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
