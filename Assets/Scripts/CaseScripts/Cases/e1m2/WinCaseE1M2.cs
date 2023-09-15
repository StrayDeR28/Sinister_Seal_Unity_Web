using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCaseE1M2 : MonoBehaviour
{
    [SerializeField] GameObject back;
    Image[] frames;
    [SerializeField] List<Color32> usedColors;
    [SerializeField] int paintedCount;
    [SerializeField] GameObject WrongAnswerText;

    public void SetCount()
    {
        paintedCount++;
    }

    bool indigo;
    bool orange;
    bool violet;
    bool blue;
    bool lime;
    bool green;
    
    public void Awake()
    {
        frames = back.GetComponentsInChildren<Image>();
    }

    public void CaseWin()
    {
        usedColors.Clear();
        foreach (var frame in frames) if(!usedColors.Contains(frame.color)) usedColors.Add(frame.color);
        usedColors.Remove(Color.white);

        bool indigo = usedColors.Contains(new Color32(64, 0, 147, 255));
        bool orange = usedColors.Contains(new Color32(255, 210, 1, 255));
        bool violet = usedColors.Contains(new Color32(166, 33, 113, 255));
        bool blue = usedColors.Contains(new Color32(38, 88, 215, 255));
        bool lime = usedColors.Contains(new Color32(222, 255, 19, 255));
        bool green = usedColors.Contains(new Color32(46, 112, 49, 255));

        if(usedColors.Count < 3)
            if((indigo && orange || indigo && violet || violet && orange ||
                violet && blue   || blue && orange   || indigo && lime ||
                violet && lime   || green && orange  || green && lime) &&
                paintedCount > 5)
                {
                    print("крутой");
                    gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
                }
                else
                {
                    SetTrueWrongAnswer();
                    Invoke("SetFalseWrongAnswer",5f);
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
