using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaOutdoor : MonoBehaviour
{
    public int      _players;
    public int      _vilan;
    private string   _jogadores;
    private string   _vilao;
    public Text     _vencedor;

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
}
