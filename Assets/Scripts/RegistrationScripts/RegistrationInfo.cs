using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RegistrationInfo : MonoBehaviour
{
    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField nickname;
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_InputField surname;
    [SerializeField] private TMP_InputField patronymic;
    [SerializeField] private Toggle togglePatronymic;
    [SerializeField] private Toggle togglePrivacyPolicy;
    [SerializeField] private TMP_Text debugText;

    private bool infoCheck = false;
    private bool authorizationCheck = false;//Флаг для проверки на авторизованного пользователя (совпадение почты и пароля)

    [SerializeField] private CheckInfoEnum checkInput = CheckInfoEnum.None;

    [SerializeField] private enum CheckInfoEnum { None = 0, LoginInfo = 1, RegistrationInfo = 2 };
    public enum DebugErrorEnum { None = 0, EmptyInputFields = 1, AnuthorizedUser = 2 };

    public void CheckInfo()
    {
        switch (checkInput)
        {
            case CheckInfoEnum.LoginInfo:
                //if (email.text.Length != 0 && password.text.Length != 0) { infoCheck = true; }
                infoCheck = email.text.Length != 0 && password.text.Length != 0;
                break;
            case CheckInfoEnum.RegistrationInfo:
                //if (email.text.Length != 0 && password.text.Length != 0 && nickname.text.Length != 0 && userName.text.Length != 0 && 
                //   (surname.text.Length != 0 || togglePatronymic.isOn == true) && patronymic.text.Length != 0 && togglePrivacyPolicy.isOn == true) { infoCheck = true; }
                infoCheck = email.text.Length != 0 &&
                            password.text.Length != 0 &&
                            nickname.text.Length != 0 &&
                            userName.text.Length != 0 &&
                            surname.text.Length != 0 &&
                            togglePrivacyPolicy.isOn &&
                            (togglePatronymic.isOn ||
                            patronymic.text.Length != 0);
                break;
        }
    }

    public void SendLogin()
    {
        if (infoCheck == false)
        {
            ErrorInputInfo(DebugErrorEnum.EmptyInputFields);
        }
        else
        {
            //код Германа
            ErrorInputInfo(DebugErrorEnum.None);
            print("email: " + email.text);
            authorizationCheck=true;    
            /*
             * ЭТО временный вариант, очевидно менять флаг только после получения ответа от сервера. Тут же вызвать LoadScene из LSAS класса
             * Если пользователь не авторизован - поставить infoCheck = false
             */
        }
        
    }
    public void SendPassword()
    {
        if (infoCheck == false)
        {
            ErrorInputInfo(DebugErrorEnum.EmptyInputFields);
        }
        else
        {
            //код Германа
            ErrorInputInfo(DebugErrorEnum.None);
            print("password: " + password.text);
        }
    }
    public void SendNickname()
    {
        if (infoCheck == false)
        {
            ErrorInputInfo(DebugErrorEnum.EmptyInputFields);
        }
        else
        {
            //код Германа
            ErrorInputInfo(DebugErrorEnum.None);
            print("nickname: " + nickname.text);
        }
    }
    public void SendName()
    {
        if (infoCheck == false)
        {
            ErrorInputInfo(DebugErrorEnum.EmptyInputFields);
        }
        else
        {
            //код Германа
            ErrorInputInfo(DebugErrorEnum.None);
            print("Name: " + userName.text);
        }
    }
    public void SendSurname()
    {
        if (infoCheck == false)
        {
            ErrorInputInfo(DebugErrorEnum.EmptyInputFields);
        }
        else
        {
            //код Германа
            ErrorInputInfo(DebugErrorEnum.None);
            print("Surname: " + surname.text);
        }
    }
    public void SendPatronymic()
    {
        if (infoCheck == false)
        {
            ErrorInputInfo(DebugErrorEnum.EmptyInputFields);
        }
        else
        {
            //код Германа
            ErrorInputInfo(DebugErrorEnum.None);
            if (togglePatronymic.isOn)
            {
                print("Patronymic: no patronymic");//имитация отправки на сервер при осутсвии отчества
            }
            else
            {
                print("Patronymic: " + patronymic.text);
            }
        }
    }
    public void ErrorInputInfo( DebugErrorEnum errorCode)
    {
        switch (errorCode)
        {
            case DebugErrorEnum.None:
                debugText.text = "----";
                break;
            case DebugErrorEnum.EmptyInputFields:
                debugText.text = "Заполните поля ввода";
                break;
            case DebugErrorEnum.AnuthorizedUser:
                debugText.text = "Неправильный почтовый адресс или пароль";
                break;
        }
    }
    public bool GetAuthCheck()
    {
        return(authorizationCheck);
    }
}
