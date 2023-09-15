using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataNew : MonoBehaviour
{
    //Здесь храниться информация о всех (новых) PlayerPrefs проекта.
    //PlayerPrefs: "PlayerName" - для выделения имени игрока в текстах; "StorySceneToLoad" - индикатор для загрузки StoryScene, сохранение
    private void Start()
    {
        PlayerPrefs.SetString("PlayerName", "Ivan");//разместить это в другом месте, в поле ввода
        PlayerPrefs.SetInt("StorySceneToLoad", 0);// Пример, сцена после алхимии. Задаваться будет в другом месте
    }
}
