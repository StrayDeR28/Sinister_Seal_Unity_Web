using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZoomSound : MonoBehaviour
{
    [SerializeField] private AudioSource ZoomSound;
    public void PlayZoomSoundd()
    {
        ZoomSound.Play();
    }
}
