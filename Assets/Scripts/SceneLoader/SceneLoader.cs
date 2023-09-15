using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private LoadingIndicatorSO loadingIndicatorSO;
    private string sceneName;
    [SerializeField] private ScenesEnum LoadNextScene = ScenesEnum.Registration;

    [SerializeField] private enum ScenesEnum {None=0, Registration=1, Novell1=2, Map=3, Case=4, NovellScene21=5, NovellScene22 = 6, Statistic = 7, CaseWide = 8, Credits = 9};
    public void LoadScene()
    {
        Time.timeScale = 1f;
        switch (LoadNextScene)
        {
            case ScenesEnum.Registration:
                sceneName = "RegistrationScene";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.Novell1:
                sceneName = "NovellScene1";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.Map:
                sceneName = "MapScene";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.Case:
                sceneName = "CaseSceneMain";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.CaseWide:
                sceneName = "CaseSceneWide";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.NovellScene21:
                sceneName = "NovellScene2.1";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.NovellScene22:
                sceneName = "NovellScene2.2";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.Statistic:
                sceneName = "StatisticScene";
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
            case "RegistrationScene":
                LoadNextScene = ScenesEnum.Registration;
                LoadScene();
                break;
            case "NovellScene1":
                LoadNextScene = ScenesEnum.Novell1;
                LoadScene();
                break;
            case "NovellScene2.1":
                LoadNextScene = ScenesEnum.NovellScene21;
                break;
            case "NovellScene2.2":
                LoadNextScene = ScenesEnum.NovellScene22;
                break;
            case "Map":
                LoadNextScene = ScenesEnum.Map;
                LoadScene();
                break;
            case "StatisticScene":
                LoadNextScene = ScenesEnum.Statistic;
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
            case "RegistrationScene":
                LoadNextScene = ScenesEnum.Registration;
                break;
            case "NovellScene1":
                LoadNextScene = ScenesEnum.Novell1;
                break;
            case "NovellScene2.1":
                LoadNextScene = ScenesEnum.NovellScene21;
                break;
            case "NovellScene2.2":
                LoadNextScene = ScenesEnum.NovellScene22;
                break;
            case "Map":
                LoadNextScene = ScenesEnum.Map;
                break;
            case "StatisticScene":
                LoadNextScene = ScenesEnum.Statistic;
                break;
            case "CreditsScene":
                LoadNextScene = ScenesEnum.Credits;
                break;
        }
    }
}
