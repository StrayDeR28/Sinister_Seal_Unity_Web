using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowPassword : MonoBehaviour
{
    [SerializeField] private TMP_InputField password;
    [SerializeField] private Sprite showPasswordSprite;
    [SerializeField] private Sprite hidePasswordSprite;

    public void ChangeContentType()
    {
        if (password.contentType == TMP_InputField.ContentType.Password)
        {
            password.contentType = TMP_InputField.ContentType.Standard;
            password.ForceLabelUpdate();
            GetComponent<Image>().sprite = showPasswordSprite; 
        }
        else if (password.contentType == TMP_InputField.ContentType.Standard)
        {
            password.contentType = TMP_InputField.ContentType.Password;
            password.ForceLabelUpdate();
            GetComponent<Image>().sprite = hidePasswordSprite;
        }
    }
}
