using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextHighlight : MonoBehaviour
{
    public void UnderlineON()
    {
        GetComponentInChildren<TMP_Text>().fontStyle |= FontStyles.Underline;
    }
    public void UnderlineOFF()
    {
        GetComponentInChildren<TMP_Text>().fontStyle ^= FontStyles.Underline;
    }
}
