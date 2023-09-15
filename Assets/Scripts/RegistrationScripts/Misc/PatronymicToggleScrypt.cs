using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PatronymicToggleScrypt : MonoBehaviour
{
    [SerializeField] private TMP_InputField patronymic;

    public void SetActive()
    {
        /*if(gameObject.GetComponent<Toggle>().isOn == true)
        {
            patronymic.interactable=false;
        }
        else
        {
            patronymic.interactable=true;
        }*/
        
        patronymic.interactable = !GetComponent<Toggle>().isOn;
        patronymic.text = string.Empty;
    }
}
