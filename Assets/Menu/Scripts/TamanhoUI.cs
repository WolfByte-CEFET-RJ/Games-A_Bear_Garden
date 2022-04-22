using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TamanhoUI : MonoBehaviour
{
    public Slider       _tamanhoUI;
    public GameObject   _uiMenu;
    public GameObject   _uiFase;

    void Start()
    {
        _tamanhoUI.value = PlayerPrefs.GetFloat("ui", (_tamanhoUI.value));
    }

    void Update()
    {
        _tamanhoUI.GetComponent<Slider>();
        _uiMenu.GetComponent<RectTransform>().localScale = new Vector3(_tamanhoUI.value, _tamanhoUI.value, _tamanhoUI.value);
        _uiFase.GetComponent<RectTransform>().localScale = new Vector3(_tamanhoUI.value, _tamanhoUI.value, _tamanhoUI.value);

        PlayerPrefs.SetFloat("ui", (_tamanhoUI.value));
    }
}
