using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinCaceE3M1 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;
    [SerializeField] GameObject WrongAnswerText;
    public void CaseWin()
    {
        if (answerInputField.text != null && (answerInputField.text == "2, 30")) 
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
