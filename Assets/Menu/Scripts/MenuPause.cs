using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    [Header("Pause e Menus")]
    public GameObject   _pausePainel;   //Natty Variavel do GameObject do "MenuPause"
    //public GameObject   _Canvas;        //Natty Insira o GameObject com todos os Canvas da fase dentro
    public bool         _estaPausado;   //Natty Bool sobre o Pause

    //Natty Lembre-se de manter o CanvasMenuPause como false para não abrir quando o jogo começa

    void Start()
    {
        Time.timeScale = 1f;                //Natty Tempo do jogo = 1, logo se pausado vira 0 e para os elementos
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();                  //Natty Chama o Pause
        }
    }

    public void PauseScreen()
    {
        _estaPausado = true;                //Natty caracteristica para o jogo pausado
        Time.timeScale = 0f;
        _pausePainel.SetActive(true);
        //_Canvas.SetActive(false);
        Debug.Log("Jogo Pausado!");
    }

    public void RetomarFase()
    {
        _estaPausado = false;               //Natty caracteristicas para voltar ao jogo (inversas ao pause)
        Time.timeScale = 1f;
        _pausePainel.SetActive(false);
        //_Canvas.SetActive(true);
        Debug.Log("Retomou Fase!");
    }

    public void VoltaparaMenu()
    {
        SceneManager.LoadScene("Menu");     //Natty vai para o menu
        Time.timeScale = 1f;
        Debug.Log("Voltou para Menu Principal!");
    }

    public void InstrucaoScreen()
    {
        Time.timeScale = 0f;                //Natty Pausa ao abrir as instruções
        _pausePainel.SetActive(true);
        //_Canvas.SetActive(false);
        Debug.Log("Jogo Pausado Pelas Instruções!");
    }
}
