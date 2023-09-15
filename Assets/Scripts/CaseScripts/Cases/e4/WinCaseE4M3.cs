using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCaseE4M3 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;
    [SerializeField] GameObject WrongAnswerText;

    public void CaseWin()
    {
        if(answerInputField.text == "HJE, CTF, 2802" || answerInputField.text == "hje, ctf, 2802") // ", , 3039"
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
