using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public TextMeshProUGUI bits;
    public TextMeshProUGUI bytes;
    public GameObject NewRankMiddle;
    public GameObject NewRankSenior;
    public GameObject Congratulations;
    public Slider slider;

    [SerializeField] private WebManager webManager;
    void Awake()
    {
        bits.SetText((WebManager.player.bits%8).ToString());
        bytes.text = (WebManager.player.bits/8).ToString();
        UpdateProgress();
        SetNewRank();
        switch (WebManager.player.title)
        {
            case RankCode.middle:
                NewRankMiddle.GetComponent<NewRank>().Pause();
                break;
            case RankCode.senior:
                NewRankSenior.GetComponent<NewRank>().Pause();
                break;
            case RankCode.samurai:
                Congratulations.GetComponent<NewRank>().Pause();
                break;
        }
    }
    public void SetNewRank()
    {
        if (WebManager.player.title == RankCode.junior && WebManager.player.bits >= 24)
        {
            webManager.DataUpdate("title", 1);
            WebManager.player.title = RankCode.middle;
        }
        else if (WebManager.player.title == RankCode.middleEarn && WebManager.player.bits >= 40)
        {
            webManager.DataUpdate("title", 3);
            WebManager.player.title = RankCode.senior;
        }
        else if (WebManager.player.title == RankCode.seniorEarn && WebManager.player.bits >= 56)
        {
            webManager.DataUpdate("title", 5);
            WebManager.player.title = RankCode.samurai;
        }
        else if (WebManager.player.title == RankCode.samurai)
        {
            webManager.DataUpdate("title", 6);
            WebManager.player.title = RankCode.samuraiEarn;
        }
    }
    public void UpdateProgress()
    {
        slider.value = WebManager.player.bits;
    }
    public void ProgressForTutorial(string tutorialProgress)
    {
        switch (tutorialProgress)
        {
            case "showMiddle": 
                slider.value = 24; 
                break;
            case "showSenior":
                slider.value = 40;
                break;
            case "showSamurai":
                slider.value = 56;
                break;
        }
    }
}
