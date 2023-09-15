using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountRatingPoints : MonoBehaviour
{
    [SerializeField] private GameObject timeGO;
    [SerializeField] private int ratingPoints;
    private PointsEnum difficultyLevel;
    [SerializeField] private TMP_Text bitsCount;
    [SerializeField] private AudioSource winSound;

    [SerializeField] private WebManager webManager;

    [SerializeField] private enum PointsEnum {Easy = 10, Medium = 20, Hard = 40};//макс значение очков рейтинга за уровень

    private void Awake()
    {
        winSound.Play();
        bitsCount.text = "+" + (int)difficultyLevel/10;
        CalculateRatingPoints();
    }
    public void TakeDifficultyLevel(int difLevel)
    {
        switch (difLevel%4)
        {
            case 0:
                difficultyLevel = PointsEnum.Easy;
                WebManager.player.bits += 1;
                break;
            case 1:
                difficultyLevel = PointsEnum.Easy;
                WebManager.player.bits += 1;
                break;
            case 2:
                difficultyLevel = PointsEnum.Medium;
                WebManager.player.bits += 2;
                break;
            case 3:
                difficultyLevel = PointsEnum.Hard;
                WebManager.player.bits += 4;
                break;
        }
        webManager.DataUpdate("bits", WebManager.player.bits);
    }
    public void CalculateRatingPoints()
    {
        if (PlayerPrefs.GetInt("CaseLeft") != int.Parse(PlayerPrefs.GetString("levelIndex")))
        {
            float time = timeGO.GetComponent<Stopwatch>().GetCurrentTime();
            time = (int)time / 30;//время, через которое снимется очко рейтинга (в секундах)
            ratingPoints = (int)difficultyLevel - (int)time;
            if (ratingPoints <= ((int)difficultyLevel / 2))
            {
                ratingPoints = (int)difficultyLevel / 2;
            }
        }
        else
        {
            ratingPoints = (int)difficultyLevel / 2;
        }
        SendRating();
    }
    
    public void SendRating()
    {
        int index = int.Parse(PlayerPrefs.GetString("levelIndex"));
        string caseString = "e" + (index / 4 + 1).ToString() + "m" + (index % 4 + 1).ToString();
        webManager.DataUpdate(caseString, ratingPoints);
        WebManager.player.progress[index] = ratingPoints;
        PlayerPrefs.SetInt("CaseLeft", -1);
    }
}
