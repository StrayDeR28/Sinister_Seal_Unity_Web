using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NicknameWriter : MonoBehaviour
{
    private void Awake()
    {
        string nickname = WebManager.player.nickname;
        gameObject.GetComponent<TMP_Text>().text = nickname;
    }
}
