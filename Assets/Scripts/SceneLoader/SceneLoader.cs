using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private LoadingIndicatorSO loadingIndicatorSO;
    private string sceneName;
    [SerializeField] private ScenesEnum LoadNextScene = ScenesEnum.MainMenuScene;

    [SerializeField] private enum ScenesEnum {None=0, MainMenuScene = 1, Novell1=2, Alchemy=3, Credits = 4};
    public void LoadScene()
    {
        Time.timeScale = 1f;
        switch (LoadNextScene)
        {
            case ScenesEnum.MainMenuScene:
                sceneName = "MainMenuScene";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.Novell1:
                sceneName = "NovellScene1";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.Alchemy:
                sceneName = "AlchemyScene";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.Credits:
                sceneName = "CreditsScene";
                StartCoroutine(LoadSceneAsync());
                break;
        }
    }
    public void StringToEnum( string str)
    {
        switch (str)
        {
            case "MainMenuScene":
                LoadNextScene = ScenesEnum.MainMenuScene;
                LoadScene();
                break;
            case "NovellScene1":
                LoadNextScene = ScenesEnum.Novell1;
                LoadScene();
                break;
            case "AlchemyScene":
                LoadNextScene = ScenesEnum.Alchemy;
                LoadScene();
                break;
            case "CreditsScene":
                LoadNextScene = ScenesEnum.Credits;
                LoadScene();
                break;
        }
    }
    public IEnumerator LoadSceneAsync()
    {
        Instantiate(loadingIndicatorSO.loadingIndicator);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
    public void SetNextScene(string str)
    {
        switch (str)
        {
            case "MainMenuScene":
                LoadNextScene = ScenesEnum.MainMenuScene;
                break;
            case "NovellScene1":
                LoadNextScene = ScenesEnum.Novell1;
                break;
            case "AlchemyScene":
                LoadNextScene = ScenesEnum.Alchemy;
                break;
            case "CreditsScene":
                LoadNextScene = ScenesEnum.Credits;
                break;
        }
    }
}
