using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinCaseE3M4 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;
    [SerializeField] GameObject WrongAnswerText;
    public void CaseWin()
    {
        if (answerInputField.text != null && (answerInputField.text.Replace(" ", "") == "1,4,2,3")) 
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