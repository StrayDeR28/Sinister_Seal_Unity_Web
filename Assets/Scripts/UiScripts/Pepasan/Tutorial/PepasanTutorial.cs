using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PepasanTutorial : MonoBehaviour
{
    [SerializeField] private GameObject pepasanTalkTutorial;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button caseButton;
    [SerializeField] private GameObject progressBar;
    [SerializeField] private GameObject palace;
    [SerializeField] private Button mapZoomButton;
    [SerializeField] private Button menuStatisticButton;

    [SerializeField] private GameObject progressbarBackground;
    [SerializeField] private GameObject provinceBackground;
    [SerializeField] private GameObject caseBackground;
    [SerializeField] private GameObject mainBackground;
    [SerializeField] private GameObject menuBackground;

    [SerializeField] private WebManager webManager;

    private int step = 0;
    public void TutorialNextStep()
    {
        step++;
        if (step <= 26)
        {
            switch (step)
            {
                case 2:
                    menuStatisticButton.interactable = false;
                    menuStatisticButton.GetComponentInChildren<TMP_Text>().color = new Color32(166, 166, 166, 255);
                    palace.GetComponent<Canvas>().overrideSorting=false;
                    mainBackground.SetActive(false);
                    progressbarBackground.SetActive(true);
                    break;
                case 6:
                    progressBar.GetComponent<ProgressBar>().ProgressForTutorial("showMiddle");
                    break;
                case 7:
                    progressBar.GetComponent<ProgressBar>().ProgressForTutorial("showSenior");
                    break;
                case 8:
                    progressBar.GetComponent<ProgressBar>().ProgressForTutorial("showSamurai");
                    break;
                case 9:
                    progressbarBackground.SetActive(false);
                    menuBackground.SetActive(true);
                    break;
                case 11:
                    menuBackground.SetActive(false);
                    menuBackground.transform.GetChild(0).gameObject.SetActive(false);
                    provinceBackground.SetActive(true);
                    mapZoomButton.interactable = false;
                    nextTextButton.interactable = false;
                    break;
                case 12:
                    provinceBackground.SetActive(false);
                    menuBackground.SetActive(true);
                    nextTextButton.interactable = true;
                    break;
                case 14:
                    mapZoomButton.interactable = true;
                    nextTextButton.interactable = false;
                    break;
                case 15:
                    mapZoomButton.interactable = false;
                    menuBackground.SetActive(false);
                    provinceBackground.SetActive(true);
                    break;
                case 16:
                    nextTextButton.interactable = true;
                    provinceBackground.transform.GetChild(0).gameObject.SetActive(false);
                    provinceBackground.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                    caseBackground.SetActive(true);
                    caseButton.interactable = false;
                    break;
                case 26:
                    caseButton.interactable = true;

                    webManager.DataUpdate("tutorial", 1);
                    WebManager.player.tutorial = true;
                    break;
            }
            pepasanTalkTutorial.GetComponent<PeposanTalk>().TakeElementNumber(step);
            gameObject.GetComponent<PeposanAnimation>().PlayPepasanSequence("tutorial");
        }
    }
    public void DestroyAll()
    {
        Destroy(menuBackground);
        Destroy(progressbarBackground);
        Destroy(provinceBackground);
        Destroy(caseBackground);
        Destroy(mainBackground);
        Destroy(gameObject);
    }
}
