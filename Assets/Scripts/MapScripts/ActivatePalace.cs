using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePalace : MonoBehaviour
{
    [SerializeField] private Image image;
    private int bits;
    //[SerializeField] private GameObject particles;
    private void Awake()
    {
        bits = WebManager.player.bits;
        if (bits >= 40 && bits < 56)
        {
            gameObject.GetComponent<Image>().sprite = image.sprite;
            gameObject.GetComponent<Button>().interactable = true;
            //particles.gameObject.SetActive(true);
            gameObject.GetComponent<SceneLoader>().SetNextScene("NovellScene2.1");
        }
        else if (bits >= 56)
        {
            gameObject.GetComponent<Image>().sprite = image.sprite;
            gameObject.GetComponent<Button>().interactable = true;
            //particles.gameObject.SetActive(true);
            gameObject.GetComponent<SceneLoader>().SetNextScene("NovellScene2.2");
        }
    }
}