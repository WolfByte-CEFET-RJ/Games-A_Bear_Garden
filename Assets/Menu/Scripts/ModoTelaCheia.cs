using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModoTelaCheia : MonoBehaviour
{
    private int _modoTelaCheia;
    public Text _txtTela;

    void Start()
    {
        telaCheiaConfig();
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("_modoTelaCheia"))
        {
            _modoTelaCheia = PlayerPrefs.GetInt("_modoTelaCheia");
            if (_modoTelaCheia == 0)
            {
                _txtTela.text = "Desligado";
                Screen.fullScreen = false;
            }
            else
            {
                _txtTela.text = "Ligado";
                Screen.fullScreen = true;
            }
        }
        else
        {
            _modoTelaCheia = 1;
            PlayerPrefs.SetInt("_modoTelaCheia", _modoTelaCheia);
            Screen.fullScreen = true;
            _txtTela.text = "Ligado";
        }
    }

    public void telaCheiaConfig()
    {
        Debug.Log(_modoTelaCheia);
        if (_modoTelaCheia == 1)
        {
            Screen.fullScreen = false;
            _txtTela.text = "Desligado";
            _modoTelaCheia = 0;
        }
        else
        {
            Screen.fullScreen = true;
            _modoTelaCheia = 1;
            _txtTela.text = "Ligado";
        }
        PlayerPrefs.SetInt("_modoTelaCheia", _modoTelaCheia);
        _modoTelaCheia = PlayerPrefs.GetInt("_modoTelaCheia");
    }
}