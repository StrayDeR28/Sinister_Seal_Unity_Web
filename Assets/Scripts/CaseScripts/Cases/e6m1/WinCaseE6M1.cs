using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE6M1 : MonoBehaviour
{
    [SerializeField] private int pieceCounter=0;
    [SerializeField] GameObject WrongAnswerText;
    public void SetPieceCounter()
    {
        pieceCounter++;
        print(pieceCounter);
    }
    public void CaseWin()
    {
        if ( pieceCounter == 20 )//кол-во элементов для завершения
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
