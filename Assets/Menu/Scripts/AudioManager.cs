using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer _mixer;
    
    public const string Musica_Chave = "musicaVolume";
    public const string SFX_Chave = "sFXVolume";
    public const string Master_Chave = "masterVolume";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LoadVolume()
    {
        float musicaVolume = PlayerPrefs.GetFloat(Musica_Chave, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_Chave, 1f);
        float masterVolume = PlayerPrefs.GetFloat(Master_Chave, 1f);
    }

}
