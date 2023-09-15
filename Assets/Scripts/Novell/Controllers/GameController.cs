using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameScene currentScene;
    public BottomBarController bottomBar;
    public SpriteSwitcher backgroundController;
    public ChooseController chooseController;
    public AudioController audioController;

    private State state = State.IDLE;

    private List<StoryScene> history = new List<StoryScene>();

    [SerializeField] private GameObject pauseMenu;

    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }

    void Start()
    {
        if (currentScene is StoryScene)
        {
            StoryScene storyScene = currentScene as StoryScene;
            history.Add(storyScene);
            bottomBar.PlayScene(storyScene);
            backgroundController.SetImage(storyScene.background);
            PlayAudio(storyScene.sentences[0]);
        }
    }

    void Update()
    {
        if (state == State.IDLE)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && pauseMenu.GetComponent<Menu>().GetActivityFlag() == false)
            {
                if (bottomBar.IsCompleted())
                {
                    bottomBar.StopTyping();
                    if (bottomBar.IsLastSentence())
                    {
                        if ((currentScene as StoryScene).nextScene == null)
                        {
                            if (SceneManager.GetActiveScene().name == "NovellScene1")
                            {
                                gameObject.GetComponent<WebManager>().DataUpdate("novel1", 1);
                                WebManager.player.novel1 = true;
                            }
                            else if (SceneManager.GetActiveScene().name == "NovellScene2.2" || SceneManager.GetActiveScene().name == "NovellScene2.1") 
                            {
                                WebManager.player.novel2 = false;
                            }
                            gameObject.GetComponent<SceneLoader>().LoadScene();
                        }
                        else
                        {
                            PlayScene((currentScene as StoryScene).nextScene);
                        }
                    }
                    else
                    {
                        bottomBar.PlayNextSentence();
                        PlayAudio((currentScene as StoryScene)
                            .sentences[bottomBar.GetSentenceIndex()]);
                    }
                }
                else
                {
                    bottomBar.SpeedUp();
                }
            }
            if (Input.GetMouseButtonDown(1) && pauseMenu.GetComponent<Menu>().GetActivityFlag() == false)
            {
                if (bottomBar.IsFirstSentence())
                {
                    if (history.Count > 1)
                    {
                        bottomBar.StopTyping();
                        bottomBar.HideSprites();
                        history.RemoveAt(history.Count - 1);
                        StoryScene scene = history[history.Count - 1];
                        history.RemoveAt(history.Count - 1);
                        PlayScene(scene, scene.sentences.Count - 2, false);
                    }
                }
                else
                {
                    bottomBar.GoBack();
                }
            }
        }
    }

    public void PlayScene(GameScene scene, int sentenceIndex = -1, bool isAnimated = true)
    {
        StartCoroutine(SwitchScene(scene, sentenceIndex, isAnimated));
    }

    private IEnumerator SwitchScene(GameScene scene, int sentenceIndex = -1, bool isAnimated = true)
    {
        state = State.ANIMATE;
        currentScene = scene;
        if (isAnimated)
        {
            bottomBar.Hide();
            yield return new WaitForSeconds(1f);
        }
        if (scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            history.Add(storyScene);
            PlayAudio(storyScene.sentences[sentenceIndex + 1]);
            if (isAnimated)
            {
                backgroundController.SwitchImage(storyScene.background);
                yield return new WaitForSeconds(1f);
                bottomBar.ClearText();
                bottomBar.Show();
                yield return new WaitForSeconds(1f);
            }
            else
            {
                backgroundController.SetImage(storyScene.background);
                bottomBar.ClearText();
            }
            bottomBar.PlayScene(storyScene, sentenceIndex, isAnimated);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }

    private void PlayAudio(StoryScene.Sentence sentence)
    {
        audioController.PlayAudio(sentence.music, sentence.sound);
    }
}
