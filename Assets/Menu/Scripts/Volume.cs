using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [Header("Mixer e Sliders")]
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider     _musicaSlider;
    [SerializeField] Slider     _sfxSlider;
    [SerializeField] Slider     _masterSlider;

    public const string Mixer_Musica = "MusicaVolume";
    public const string Mixer_SFX    = "SFXVolume";
    public const string Mixer_Master = "MasterVolume";

    private void Awake()
    {
        _musicaSlider.onValueChanged.AddListener(SetMusicaVolume);
        _sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        _masterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    private void Start()
    {
        _musicaSlider.value = PlayerPrefs.GetFloat(AudioManager.Musica_Chave, 1f);
        _sfxSlider.value    = PlayerPrefs.GetFloat(AudioManager.SFX_Chave,    1f);
        _masterSlider.value = PlayerPrefs.GetFloat(AudioManager.Master_Chave, 1f);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.Musica_Chave, _musicaSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_Chave,    _sfxSlider.value);
        PlayerPrefs.SetFloat(AudioManager.Master_Chave, _masterSlider.value);
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