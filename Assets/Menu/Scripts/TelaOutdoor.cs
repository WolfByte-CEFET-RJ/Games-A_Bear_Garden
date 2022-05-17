using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaOutdoor : MonoBehaviour
{
    public int       _players;
    public int       _vilan;
    private string   _jogadores;
    private string   _vilao;
    public Text      _vencedor;
    public bool      _estaPausado;


    void Start()
    {
        _jogadores = "Jogadores Venceram!";
        _vilao     = "Vilão Venceu!";
    }

    void Update()
    {
        _players = 5;//PlayerPrefs.GetInt("pontos1") | PlayerPrefs.GetInt("pontosJ2");
        _vilan   = 11; //PlayerPrefs.GetInt("pontosVL");

        if (_players > _vilan)
        {
            _vencedor.text = _jogadores.ToString();
        }

        else if (_vilan > _players)
        {
            _vencedor.text = _vilao.ToString();
        }
    }

    public void OnButtaoPress()
    {
        _estaPausado = !_estaPausado;
        PauseScene();
    }

    public void PauseScene()
    {
        if (_estaPausado)                     //Ferrari Adicionei o if para retomar o jogo ou pausar
        {
            Time.timeScale = 0;
            //_Canvas.SetActive(false);
            Debug.Log("Fim de Jogo!");
        }
        else
        {
            Time.timeScale = 1;
            //_Canvas.SetActive(true);
            Debug.Log("Retomou Fase!");
        }
    }
}
