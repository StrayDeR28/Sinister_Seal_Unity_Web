using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [System.Serializable]
    public struct MenuLogin
    {
        public TMP_InputField email, password;
        public TMP_Text emailError, passwordError;

        public void SetError(Sprite source) {
            if(email.text.Length == 0) email.image.sprite = source;
            if(password.text.Length == 0) password.image.sprite = source;
        }
    }

    [System.Serializable]
    public struct MenuSignup
    {
        public TMP_InputField firstName, middleName, lastName, email, nickName, password;
        public Toggle toggleLastName, togglePrivacy;
        public TMP_Text emailError, nicknameError;

        public void SetError(Sprite sourceShort, Sprite sourceLong) {
            if(firstName.text.Length == 0) firstName.image.sprite = sourceShort;
            if(middleName.text.Length == 0) middleName.image.sprite = sourceShort;
            if(lastName.text.Length == 0) lastName.image.sprite = sourceShort;
            if(email.text.Length == 0) email.image.sprite = sourceLong;
            if(nickName.text.Length == 0) nickName.image.sprite = sourceLong;
            if(password.text.Length == 0) password.image.sprite = sourceLong;
        }
    }

    public Sprite errorLongField;
    public Sprite errorShortField;

    public MenuLogin loginWindow;
    public MenuSignup signupWindow;
    
    public WebManager webManager;

    public Button signupButton;

    public void OnSignupSet()
    {
        signupButton.image.color = new Color32(100, 255, 80, 255);
        signupButton.GetComponentInChildren<TMP_Text>().text = "Регистрация успешна";
    }
    public void OnSignupReset()
    {
        signupButton.image.color = Color.white;
        signupButton.GetComponentInChildren<TMP_Text>().text = "Зарегистрироваться";
    }

    public void WebError()
    {
        switch(WebManager.player.error)
        {
            case ErrorCode.loginEmailError:
                loginWindow.emailError.gameObject.SetActive(true);
                loginWindow.email.image.sprite = errorLongField;
                break;
            case ErrorCode.loginPassError:
                loginWindow.passwordError.gameObject.SetActive(true);
                loginWindow.password.image.sprite = errorLongField;
                break;
            case ErrorCode.signupEmailError:
                signupWindow.emailError.gameObject.SetActive(true);
                signupWindow.email.image.sprite = errorLongField;
                break;
            case ErrorCode.signupNickError:
                signupWindow.nicknameError.gameObject.SetActive(true);
                signupWindow.nickName.image.sprite = errorLongField;
                break;
        }
    }

    public void Login()
    {
        if(CheckLogin(loginWindow)) webManager.Login(loginWindow);
        else loginWindow.SetError(errorLongField);
    }
    public void Signup()
    {    
        if(CheckSignup(signupWindow)) webManager.Signup(signupWindow);
        else signupWindow.SetError(errorShortField, errorLongField);
    }

    bool CheckLogin(MenuManager.MenuLogin window)
    {
        return  window.email.text.Length != 0 && 
                window.password.text.Length != 0;
    }
    bool CheckSignup(MenuManager.MenuSignup window)
    {
        return  window.email.text.Length != 0 &&
                window.nickName.text.Length != 0 &&
                window.password.text.Length != 0 &&
                window.firstName.text.Length != 0 &&
                window.middleName.text.Length != 0 &&
                window.togglePrivacy.isOn &&
                (window.toggleLastName.isOn ||
                window.lastName.text.Length != 0);
    }
}
