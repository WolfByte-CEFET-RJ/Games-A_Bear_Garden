using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TamanhoUI : MonoBehaviour
{
    public Slider       _tamanhoUI;     //Natty Slider de UI
    public GameObject   _uiInterface;   //Natty GameObject com os canvas da interface
    public GameObject   _uiFase;        //Natty GameObject com os canvas da fase 

    void Start()
    {
        _tamanhoUI.value = PlayerPrefs.GetFloat("ui", (_tamanhoUI.value));
    }

    void Update()
    {
        _tamanhoUI.GetComponent<Slider>();
        _uiInterface.GetComponent<RectTransform>().localScale = new Vector3(_tamanhoUI.value, _tamanhoUI.value, _tamanhoUI.value);
        _uiFase.GetComponent<RectTransform>().localScale = new Vector3(_tamanhoUI.value, _tamanhoUI.value, _tamanhoUI.value);

        PlayerPrefs.SetFloat("ui", (_tamanhoUI.value));
    }
}
