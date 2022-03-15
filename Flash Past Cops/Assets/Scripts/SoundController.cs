using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = slider.value;
    }
}
