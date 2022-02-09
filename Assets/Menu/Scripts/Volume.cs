using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider volumeSlider;

    public void alterarVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Debug.Log("Volume = " + volumeSlider.value);
    }
}
