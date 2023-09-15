using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class NewRank : MonoBehaviour
{
    bool activeNewRankMenu = false;

    public GameObject NewRankScreen;
    public GameObject NewRankMenu;
/*    public GameObject RaysPartical;
    public GameObject WaysPartical;
    public GameObject DotsPartical;*/

    [SerializeField] private WebManager webManager;
    [SerializeField] private AudioSource newTitleSound;
    private void Awake()
    {
        newTitleSound.Play();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && activeNewRankMenu)
        {
            Resume();
        }
    }
    public void Resume()
    {
        SetNewRank();
        /*RaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 1);
        WaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 1);
        DotsPartical.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 1);*/
        NewRankMenu.GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), 1);
        DOTween.Sequence()
        .Append(NewRankScreen.GetComponent<Image>().DOFade(0, 1))
        .AppendCallback(Animation);
    }
    public void Pause() 
    {
        Animation();
        /*RaysPartical.SetActive(activeNewRankMenu);*/
        NewRankScreen.GetComponent<Image>().DOFade(0.5f, 1);
        NewRankMenu.GetComponent<RectTransform>().DOScale(new Vector3(1,1,1), 1);
        /*RaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(10,10,0), 1);
        WaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(10,10,0), 1);
        DotsPartical.GetComponent<RectTransform>().DOScale(new Vector3(10,10,0), 1);*/
    }
    
    /*public void Resume()
    {
        RaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 1);
        WaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 2);
        DotsPartical.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 1);
        DOTween.Sequence()
        .Append(NewRankMenu.GetComponent<RectTransform>().DOScale(new Vector3(1.2f,1.2f,0), 1))
        .Append(NewRankMenu.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 1))
        .Append(NewRankScreen.GetComponent<Image>().DOFade(0, 1))
        .AppendCallback(Animation);
    }
    public void Pause() 
    {
        Animation();
        RaysPartical.SetActive(activeNewRankMenu);
        NewRankScreen.GetComponent<Image>().DOFade(0.5f, 1);
        DOTween.Sequence()
        .Append(NewRankMenu.GetComponent<RectTransform>().DOScale(new Vector3(1.2f,1.2f,0), 1))
        .Append(NewRankMenu.GetComponent<RectTransform>().DOScale(new Vector3(1,1,1), 1));
        RaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(10,10,0), 1);
        WaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(10,10,0), 1);
        DotsPartical.GetComponent<RectTransform>().DOScale(new Vector3(10,10,0), 1);
    }*/
    private void SetNewRank()
    {
        switch (WebManager.player.title)
        {
            case RankCode.middle:
                webManager.DataUpdate("title", 2);
                WebManager.player.title = RankCode.middleEarn;
                break;
            case RankCode.senior:
                webManager.DataUpdate("title", 4);
                WebManager.player.title = RankCode.seniorEarn;
                break;
        }
    }
    private void Animation()
    {
        activeNewRankMenu = !activeNewRankMenu;
        NewRankScreen.SetActive(activeNewRankMenu);
    }
}
