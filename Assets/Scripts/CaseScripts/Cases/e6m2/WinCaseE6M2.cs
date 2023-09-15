using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE6M2 : MonoBehaviour
{
    [SerializeField] private List<GameObject> pandaParts;
    [SerializeField] GameObject WrongAnswerText;
    public void CheckParts()
    {   
        bool checkCondition=false;
        foreach (GameObject item in pandaParts)
        {
            checkCondition = item.GetComponent<PandasPart>().GetColorRight();
            if (checkCondition == false)
            {
                return;
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
