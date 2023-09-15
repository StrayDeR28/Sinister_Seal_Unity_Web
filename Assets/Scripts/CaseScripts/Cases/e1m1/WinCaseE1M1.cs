using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE1M1 : MonoBehaviour
{
    [SerializeField] int count;
    [SerializeField] GameObject WrongAnswerText;
    public void SetCount()
    {
        count++;
        print(count);
    }

    public void CaseWin()
    {
        if (count == 20)
        {
            print("прошел");
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