using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider musicaSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider masterSlider;

    public const string Mixer_Musica = "MusicaVolume";
    public const string Mixer_SFX    = "SFXVolume";
    public const string Mixer_Master = "MasterVolume";

    private void Awake()
    {
        musicaSlider.onValueChanged.AddListener(SetMusicaVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    private void Start()
    {
        musicaSlider.value = PlayerPrefs.GetFloat(AudioManager.Musica_Chave, 1f);
        sfxSlider.value    = PlayerPrefs.GetFloat(AudioManager.SFX_Chave, 1f);
        masterSlider.value = PlayerPrefs.GetFloat(AudioManager.Master_Chave, 1f);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.Musica_Chave, musicaSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_Chave, sfxSlider.value);
        PlayerPrefs.SetFloat(AudioManager.Master_Chave, masterSlider.value);
    }

    void SetMusicaVolume(float value)
    {
        _mixer.SetFloat(Mixer_Musica, Mathf.Log10(value) * 20);
    }

    void SetSFXVolume(float value)
    {
        _mixer.SetFloat(Mixer_SFX, Mathf.Log10(value) * 20);
    }

    void SetMasterVolume(float value)
    {
        _mixer.SetFloat(Mixer_Master, Mathf.Log10(value) * 20);
    }
}