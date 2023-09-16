using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataNew : MonoBehaviour
{
    //Здесь храниться информация о всех (новых) PlayerPrefs проекта.
    //PlayerPrefs: "PlayerName" - для выделения имени игрока в текстах; "StorySceneToLoad" - индикатор для загрузки StoryScene, сохранение
    private void Awake()
    {
        PlayerPrefs.SetString("PlayerName", "Ivan");//разместить это в другом месте, в поле ввода
        PlayerPrefs.SetInt("StorySceneToLoad", 0);// Пример, сцена после алхимии. Задаваться будет в другом месте
        PlayerPrefs.SetInt("Achievement:1", 0);// Изначально все ачивки =0, получать в ChooseLabelController, через ChooseController/ Заменить на хранение/парсинг json?
        PlayerPrefs.SetString("Condition:potion", "");// Изначально условия не выполнены - пусты. Задавать это в нужных местах// Bomb - прописанное условие
    }
}
