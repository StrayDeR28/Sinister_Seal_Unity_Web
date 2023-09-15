using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE2M3 : MonoBehaviour
{
    int count;
    [SerializeField] int index;
    [SerializeField] GameObject currentStage;
    [SerializeField] GameObject nextStage;
    [SerializeField] GameObject WrongAnswerText;

    public void SetCount()
    {
        count++;
        print(count);
    }

    public void CaseWin()
    {
        switch (index)
        {
            case 1:
                if(count == 23)
                {
                    print("ого");
                    Destroy(currentStage);
                    nextStage.SetActive(true);
                }
                else
                {
                    SetTrueWrongAnswer();
                    Invoke("SetFalseWrongAnswer",5f);
                }
                break;
            case 2:
                if(count == 15)
                {
                    print("ага");
                    Destroy(currentStage);
                    nextStage.SetActive(true);
                }
                else
                {
                    SetTrueWrongAnswer();
                    Invoke("SetFalseWrongAnswer",5f);
                }
                break;
            case 3:
                if(count == 10)
                {
                    print("еге");
                    gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
                }
                else
                {
                    SetTrueWrongAnswer();
                    Invoke("SetFalseWrongAnswer",5f);
                }
                break;
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
