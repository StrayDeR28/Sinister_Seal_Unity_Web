using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCaseE4M1 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;
    [SerializeField] GameObject WrongAnswerText;

    public void CaseWin()
    {
        if(answerInputField.text == "8")
        {
            print("крутой");
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
