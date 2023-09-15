using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NicknameMaxLength : MonoBehaviour
{
    public void CheckLength()
    {
        if (gameObject.GetComponent<TMP_InputField>().text.Length > 12)
        {
            string substring = gameObject.GetComponent<TMP_InputField>().text;
            substring = substring.Substring(0, 12);
            gameObject.GetComponent<TMP_InputField>().text = substring;
        }
    }
}
