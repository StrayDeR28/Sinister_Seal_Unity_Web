using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNickname : MonoBehaviour
{
    private string playerName;
    private string substring = "<Имя игрока>";
    private void Awake()
    {
        playerName = WebManager.player.nickname;
        int indexOfSubstring = gameObject.GetComponent<TMP_Text>().text.IndexOf(substring);
        if (indexOfSubstring != -1)
        {
            string tmpText = gameObject.GetComponent<TMP_Text>().text;
            gameObject.GetComponent<TMP_Text>().text = tmpText.Replace(substring,"<b>" + playerName + "</b>");
        }
    }
}
