using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowAchievement : MonoBehaviour
{
    [SerializeField] private string achievementName;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject imageDone;//надо где-то хранить, пока на сцене для каждого
    [SerializeField] private TextMeshProUGUI text;
    private void Awake()
    {
        if (PlayerPrefs.GetInt(achievementName) == 1)
        {
            Sprite temp = imageDone.GetComponent<Image>().sprite;
            image.GetComponent<Image>().sprite = temp;
            text.color = Color.yellow;
        }
    }
}
