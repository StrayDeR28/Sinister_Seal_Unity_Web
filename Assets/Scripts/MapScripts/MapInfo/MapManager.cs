using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject pepasanObject;
    [SerializeField] private GameObject pepasanObjectTutorial;
    private bool tutorialFlag;
    private void Awake()
    {
        tutorialFlag = WebManager.player.tutorial;
        if (tutorialFlag == false)
        {
            StartTutorial();
        }
        if (tutorialFlag == true)
        {
            TutorialDestroyAll();
        }
        if (PlayerPrefs.GetString("caseDone") == "done")
        {
            pepasanObject.GetComponent<PeposanAnimation>().ShowPepasan("winCase");
            PlayerPrefs.SetString("levelIndex", "");
            PlayerPrefs.SetString("caseDone", "");
        }
    }
    public void StartTutorial()
    {
        pepasanObject.SetActive(false);//ставить активным после выполнения
        pepasanObjectTutorial.SetActive(true);
        pepasanObjectTutorial.GetComponent<PeposanAnimation>().ShowPepasan("tutorial");
    }
    public void SetTutorialFlag(bool flag)
    {
        //обращение к коду Германа с бека
        tutorialFlag = flag;
    }
    public bool GetTutorialFlag()
    {
        return tutorialFlag;
    }
    public void TutorialProvinceClick()
    {
        if (tutorialFlag == false)
        {
            pepasanObjectTutorial.GetComponent<PepasanTutorial>().TutorialNextStep();
        }
    }
    public void TutorialDestroyAll()
    {
        if (pepasanObjectTutorial)
        {
            pepasanObject.SetActive(true);
            pepasanObjectTutorial.GetComponent<PepasanTutorial>().DestroyAll();
        }
    }
}

