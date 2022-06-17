using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecionandoFase : MonoBehaviour
{
    [Header("Fases")]
    public int _lab;
    public int _ppt;
    public int _naves;
    [SerializeField] Text   _labText;
    [SerializeField] Text   _pptText;
    [SerializeField] Text   _navesText;
    public string  _lab_chave = "2";
    public string  _ppt_chave;
    public string  _naves_chave;

    public void Start()
    {
        _labText.text = " ";
        _pptText.text = " ";
        _navesText.text = " ";
    }

    public void Validador() //verificar se em todos os campos não tiverem repedidos e salva
    {
        PlayerPrefs.GetFloat(_labText.text, _lab);
        PlayerPrefs.GetFloat(_pptText.text, _ppt);
        PlayerPrefs.GetFloat(_navesText.text, _naves);
    }

    public void NumerandoFase()
    {
        _labText.text = "2";
        _pptText.text = "1";
        _navesText.text = "3";//_labText.text = PlayerPrefs.GetFloat(Text._lab_chave, 1f);

        /*if ()//Se nenhum valor, ao clicar vira 1
        {
            _text.text = "1";
        }
        else //Se clicado de novo, vira 2
        {
            _text.text = "2";
        }
        else //Se clicado de novo, vira 3 
        {
            _text.text = "3";
        }*/
    }

    public void SalvandoOrdem()
    {

    }
}
