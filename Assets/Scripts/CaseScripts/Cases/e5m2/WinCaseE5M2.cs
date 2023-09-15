using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE5M2 : MonoBehaviour
{   
    [SerializeField] private GameObject grid;
    [SerializeField] private List<GameObject> elementsPosition;
    [SerializeField] GameObject WrongAnswerText;
    public void CheckParts()
    {
        var gridTransform = grid.GetComponent<Transform>();
        bool checkCondition = false;
        for (int i = 0; i < gridTransform.childCount; i++) 
        {
            if (gridTransform.GetChild(i).GetChild(0) != elementsPosition[i].transform)
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
