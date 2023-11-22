using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseStorySceneToLoad : MonoBehaviour
{
    //Список Player Prefs пока здесь. Передача нужной для загрузки Story Scene пока здесь
    [SerializeField] private List<StoryScene> storyScences;
    [SerializeField] private GameObject gameController;
    private void Awake()
    {
        gameController.GetComponent<GameController>().currentScene = storyScences[PlayerPrefs.GetInt("StorySceneToLoad")];
    }
}
