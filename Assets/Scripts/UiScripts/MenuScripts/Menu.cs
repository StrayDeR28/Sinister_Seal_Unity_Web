using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private bool activeMenu = false;
    [SerializeField] private AudioSource clickSound;

    public GameObject MenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FullScreenToggle();
        }
    }
    public void Resume()
    {
        MenuUI.SetActive(false);
        Time.timeScale = 1f;
        activeMenu = false;
    }
    public void Pause() 
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        activeMenu = true;
    }
    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void PlayClickSound()
    {
        clickSound.Play();
    }

    public bool GetActivityFlag()
    {
        return activeMenu;
    }
}
