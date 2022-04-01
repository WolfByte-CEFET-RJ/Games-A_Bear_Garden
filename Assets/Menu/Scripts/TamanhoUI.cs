using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TamanhoUI : MonoBehaviour
{
    public Slider       _tamanhoUI;
    public GameObject   _ui;

    void Start()
    {
        _tamanhoUI.value = PlayerPrefs.GetFloat("ui", (_tamanhoUI.value));
    }

    void Update()
    {
        _tamanhoUI.GetComponent<Slider>();
        _ui.GetComponent<RectTransform>().localScale = new Vector3(_tamanhoUI.value, _tamanhoUI.value, _tamanhoUI.value);

        PlayerPrefs.SetFloat("ui", (_tamanhoUI.value));
    }
}
