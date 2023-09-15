using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CertificateActivation : MonoBehaviour
{
    private void Awake()
    {
        string text = gameObject.GetComponent<TMP_Text>().text;
        int bits = WebManager.player.bits;
        if (bits >= 40)
        {
            text = "Получить сертификат";
            gameObject.GetComponent<TMP_Text>().text = text;
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            bits = 40 - bits;
            text = text.Replace("<bits>", bits.ToString());
            gameObject.GetComponent<TMP_Text>().text = text;
        }
    }
}
