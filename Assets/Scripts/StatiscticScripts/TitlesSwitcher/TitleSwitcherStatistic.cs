using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleSwitcherStatistic : MonoBehaviour
{
    [SerializeField] private GameObject junior;
    [SerializeField] private GameObject middle;
    [SerializeField] private GameObject senior;
    [SerializeField] private GameObject samurai;
    [SerializeField] private TMP_Text text;
    private void Awake()
    {
        if (WebManager.player.title == RankCode.junior)
        {
            junior.SetActive(true);
            text.text = "Джун-сан";
        }
        else if (WebManager.player.title == RankCode.middle || WebManager.player.title == RankCode.middleEarn)
        {
            middle.SetActive(true);
            text.text = "Мидл-сан";
        }
        else if (WebManager.player.title == RankCode.senior || WebManager.player.title == RankCode.seniorEarn)
        {
            senior.SetActive(true);
            text.text = "Сеньор-сан";
        }
        else if (WebManager.player.title == RankCode.samurai || WebManager.player.title == RankCode.samuraiEarn)
        {
            samurai.SetActive(true);
            text.text = "Самурай";
        }
    }
}
