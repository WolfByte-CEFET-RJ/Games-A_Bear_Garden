using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour {
    
    [Header("Imagens do Mute")]
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    public bool muted = false;

    public void Start() {
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

    public void FixedUpdate()
    {
        if (muted == true)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }

    public void OnButtonPress() {
        if (muted == false)
        {
            muted = true;
            //AudioListener.pause = true;
            //AudioListener.volume = 0.0001f; //Natty
        }
        else
        {
            muted = false;
            //AudioListener.pause = false;
            //AudioListener.volume = 1f;  //Natty
        }
        UpdateButtonIcon();
    } 

    private void UpdateButtonIcon() {
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
        Save();
    }

    private void Update() {
        if(AudioListener.pause==false) {
            muted = false;
            UpdateButtonIcon();
        }
    }

    private void Load() {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save() {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
