using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintCounter : MonoBehaviour
{
    [SerializeField] private int hintsCount;
    [SerializeField] private TMP_Text hintsTextObject;
    [SerializeField] private int currentLevel;
    [SerializeField] private GameObject pepasanObject;
    [SerializeField] private GameObject pepasanTextObject;

    [SerializeField] private WebManager webManager;

    private bool pickedOnce=true; 
    private void Awake()
    {
        hintsCount = WebManager.player.hints;
        hintsTextObject.text = hintsCount.ToString();
        if (hintsCount == 0)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void UseHint()
    {
        if ((hintsCount > 0 || pickedOnce == false) && pepasanObject.GetComponent<PeposanAnimation>().GetState() == "hidden")
        {
            pepasanTextObject.GetComponent<PeposanTalk>().TakeElementNumber(currentLevel);
            pepasanObject.GetComponent<PeposanAnimation>().ShowPepasan("hint");
            pepasanObject.GetComponent<PeposanAnimation>().ChangeImageHint();
            if (pickedOnce)
            {
                hintsCount--;
                webManager.DataUpdate("hints", hintsCount);
                WebManager.player.hints = hintsCount;
                hintsTextObject.text = hintsCount.ToString();
                pickedOnce=false;
            }
        }
    }
    //нужен будет скрипт добавляющий подсказки
    public void TakeCurrentLevel(int curLevel)
    {
        currentLevel = curLevel;
    }
}
