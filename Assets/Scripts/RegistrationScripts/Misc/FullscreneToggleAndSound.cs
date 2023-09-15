using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreneToggleAndSound : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FullScreenToggle();
        }
    }
    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void PlayClickSound()
    {
        clickSound.Play();

    }
}
