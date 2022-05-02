using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    [Header("Imagens do Mute")]
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    private bool muted = false;

    public void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress() 
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
            //AudioListener.volume = 0.0001f; - Natty
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
            //AudioListener.volume = 1f; - Natty
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
