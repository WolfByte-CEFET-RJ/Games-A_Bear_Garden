using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TamanhoUI : MonoBehaviour
{
    public Slider tamanhoUI;
    public GameObject ui;

    void Start()
    {
        tamanhoUI.value = 0.75f;
    }

    void Update()
    {
        tamanhoUI.GetComponent<Slider>();
        ui.GetComponent<RectTransform>().localScale = new Vector3(tamanhoUI.value, tamanhoUI.value, tamanhoUI.value);

        PlayerPrefs.SetFloat("ui", (tamanhoUI.value));
    }
}
