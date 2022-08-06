using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    [Header("Pause e Menus")]
    public GameObject _pausePainel;   //Natty Variavel do GameObject do "MenuPause"
    public GameObject _pauseInstruction;
    //public GameObject   _Canvas;        //Natty Insira o GameObject com todos os Canvas da fase dentro
    public bool _estaPausado;   //Natty Bool sobre o Pause

    //Natty Lembre-se de manter o CanvasMenuPause como false para nao abrir quando o jogo come�a

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _estaPausado = !_estaPausado;   //Ferrari  Modifica a variavel para seu contrario
            PauseScreen();
            _pauseInstruction.SetActive(false);
        }
    }

    public void OnButtaoPress()
    {
        _estaPausado = !_estaPausado;
        PauseScreen();
    }

    public void OnInstructionPress()
    {
        _estaPausado = !_estaPausado;
        Time.timeScale = 0;
        _pauseInstruction.SetActive(true);
    }

    public void PauseScreen()
    {
        if (_estaPausado)                     //Ferrari Adicionei o if para retomar o jogo ou pausar
        {
            _pausePainel.SetActive(true);
            Time.timeScale = 0;
            //_Canvas.SetActive(false);
            Debug.Log("Jogo Pausado!");
        }
        else
        {
            _pausePainel.SetActive(false);
            Time.timeScale = 1;
            //_Canvas.SetActive(true);
            Debug.Log("Retomou Fase!");
        }
    }

    public void RetomarFase()
    {
        Time.timeScale = 1;
        _estaPausado = false;                 //Natty caracteristicas para voltar ao jogo (inversas ao pause)
        _pausePainel.SetActive(false);
        //_Canvas.SetActive(true);
        Debug.Log("Retomou Fase!");
    }


    public void VoltaparaMenu()
    {
        SceneManager.LoadScene("Menu");     //Natty vai para o menu
        Time.timeScale = 1;
        _estaPausado = false;
        _pauseInstruction.SetActive(false);
        Debug.Log("Voltou para Menu Principal!");
    }



    public void InstrucaoScreen()
    {

        Time.timeScale = 0;                //Natty Pausa ao abrir as instru��es
        _estaPausado = true;
        _pausePainel.SetActive(true);
        //_Canvas.SetActive(false);
        Debug.Log("Jogo Pausado Pelas Instru��es!");
    }
}    