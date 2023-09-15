using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    void Awake()
    {
        float tmp;
        mixer.GetFloat("musicVol", out tmp);
        gameObject.GetComponent<Slider>().value = Mathf.Pow(10, (tmp/20));
        //gameObject.GetComponent<Slider>().value = tmp / 8 + 10;
    }
    public void SetLevel(float sliderValue)
    {

        mixer.SetFloat("musicVol",Mathf.Log10(sliderValue ) * 20);
        //mixer.SetFloat("musicVol",-50 + sliderValue / 2);
        //mixer.SetFloat("musicVol",(sliderValue - 10) * 8);
    }
}
