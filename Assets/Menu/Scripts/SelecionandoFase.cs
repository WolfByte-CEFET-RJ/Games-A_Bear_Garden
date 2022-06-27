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
    //public string  _lab_chave;
    //public string  _ppt_chave;
    //public string  _naves_chave;

    
    public List<string> ids = new List<string>();
    private bool ativado_1 = false;
    private bool ativado_2 = false;
    private bool ativado_3 = false;


    public void Start()
    {
        _labText.text = " ";
        _pptText.text = " ";
        _navesText.text = " ";
    }


    public void Update() 
    {
        VerificaLista();
    }


    public void VerificaLista() 
    {
        for (int i = 0; i < ids.Count; i++) {
            int texto = i + 1;
            if (ids[i] == "ID_lab") {
                _labText.text = texto.ToString();
            } else if (ids[i] == "ID_ppt"){
                _pptText.text = texto.ToString();
            } else if (ids[i] == "ID_naves") {
                _navesText.text = texto.ToString();
            }
        }
    }

    public void OnClickButton(Button button) 
    {
        if (button.name == "_labButton") {
            if (ativado_1 == false) {
                ids.Add("ID_lab");
            } else {
                ids.Remove("ID_lab");
                _labText.text = " ";
            }
            ativado_1 = !ativado_1;
        }

        if (button.name == "_pptButton") {
            if (ativado_2 == false) {
                ids.Add("ID_ppt");
            } else {
                ids.Remove("ID_ppt");
                _pptText.text = " ";
            }
            ativado_2 = !ativado_2;
        }

        if (button.name == "_navesButton") {
            if (ativado_3 == false) {
                ids.Add("ID_naves");
            } else {
                ids.Remove("ID_naves");
                _navesText.text = " ";  
            }
            ativado_3 = !ativado_3;
        }
    }

    /*
    public void Validador() //verificar se em todos os campos n�o tiverem repedidos e salva
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

        if ()//Se nenhum valor, ao clicar vira 1
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
        }
    }

    public void SalvandoOrdem()
    {

    }
    */
}
