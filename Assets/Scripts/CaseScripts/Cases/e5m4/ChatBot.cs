using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatBot : MonoBehaviour
{
    [SerializeField] private GameObject startField;
    [SerializeField] private GameObject dataField;
    [SerializeField] private GameObject timeField;
    [SerializeField] private GameObject wisdomField;
    [SerializeField] private GameObject timeSecretField;
    [SerializeField] private GameObject photosField;
    [SerializeField] private GameObject secretDataField;
    [SerializeField] private GameObject tablesField;
    [SerializeField] private GameObject FinalField;

    [SerializeField] private GameObject currentField;
    private bool startFlag = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            EnterRequest();
        }
    }
    public void EnterRequest()
    {
        string text = gameObject.GetComponent<TMP_InputField>().text;
        if (text == null) { return; }
        if (text == "/start" && startFlag == true)//Начало
        {
            currentField = startField;
            currentField.SetActive(true);
            startFlag = false;
        }
        if (currentField == startField && text != "/start")
        {
            StartFieldRequest(text);
        }
        if (currentField == wisdomField)
        {
            WisdomFieldRequest(text);
        }
        if (currentField == timeField)
        {
            TimeFieldRequest(text);
        }
        if (currentField == timeSecretField)
        {
            TimeFieldSecretRequest(text);
        }
        if (currentField == dataField)
        {
            DataFieldRequest(text);
        }
        if (currentField == photosField)
        {
            PhotosFieldRequest(text);
        }
        if (currentField == tablesField)
        {
            TablesFieldRequest(text);
        }
        if (currentField == secretDataField)
        {
            SecretDataFieldRequest(text);
        }

    }
    private void StartFieldRequest(string text)
    {
        switch (text)
        {
            case "/data":
                currentField.SetActive(false);
                currentField = dataField;
                currentField.SetActive(true);
                break;
            case "/time":
                currentField.SetActive(false);
                currentField = timeField;
                currentField.SetActive(true);
                break;
            case "/wisdom":
                currentField.SetActive(false);
                currentField = wisdomField;
                currentField.SetActive(true);
                break;
        }
    }
    private void WisdomFieldRequest(string text)
    {
        switch (text)
        {
            case "/back":
                currentField.SetActive(false);
                currentField = startField;
                currentField.SetActive(true);
                break;
        }
    }
    private void TimeFieldRequest(string text)
    {
        switch (text)
        {
            case "/back":
                currentField.SetActive(false);
                currentField = startField;
                currentField.SetActive(true);
                break;
            case "4:57":
                currentField.SetActive(false);
                currentField = timeSecretField;
                currentField.SetActive(true);
                break;
        }
    }
    private void TimeFieldSecretRequest(string text)
    {
        switch (text)
        {
            case "/back":
                currentField.SetActive(false);
                currentField = timeField;
                currentField.SetActive(true);
                break;
        }
    }
    private void DataFieldRequest(string text)
    {
        switch (text)
        {
            case "/back":
                currentField.SetActive(false);
                currentField = startField;
                currentField.SetActive(true);
                break;
            case "/photo":
                currentField.SetActive(false);
                currentField = photosField;
                currentField.SetActive(true);
                break;
            case "/table":
                currentField.SetActive(false);
                currentField = tablesField;
                currentField.SetActive(true);
                break;
            case "/secret_data":
                currentField.SetActive(false);
                currentField = secretDataField;
                currentField.SetActive(true);
                break;
        }
    }
    private void PhotosFieldRequest(string text)
    {
        switch (text)
        {
            case "/back":
                currentField.SetActive(false);
                currentField = dataField;
                currentField.SetActive(true);
                break;
        }
    }
    private void TablesFieldRequest(string text)
    {
        switch (text)
        {
            case "/back":
                currentField.SetActive(false);
                currentField = dataField;
                currentField.SetActive(true);
                break;
        }
    }
    private void SecretDataFieldRequest(string text)
    {
        switch (text)
        {
            case "/back":
                currentField.SetActive(false);
                currentField = dataField;
                currentField.SetActive(true);
                break;
            case "Gyokuro":
                currentField.SetActive(false);
                currentField = FinalField;
                currentField.SetActive(true);
                break;
            case "gyokuro":
                currentField.SetActive(false);
                currentField = FinalField;
                currentField.SetActive(true);
                break;
        }
    }
}
