using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloqueandoCasa : MonoBehaviour
{
    /* public Animator _anim;
    public Button   _Botao;
    public bool     _selecionando;
    public bool     _jogavel;
    public bool     _ocupado; // (oncolisionwithplayer);
    public bool     _bloqueado; */

    [Header("Casinhas")]
    public bool _bloqueado; //Variavel da casinha bloqueada
    public bool _jogavel;   //variavel da casnha jogavel
    public bool _ocupado;   //variavel da casinha ocupada pelo player
    public bool _selecionavel;  //variavel da casinha disponivel para ser bloqueada
    public bool _jogada;    //variavel da jogada do vil�o
    public Button _Botao;
    //public Animation    _anim;      //Variavel para chamar as anima��es


    public void Update()    //Checa se a fun��o Pisca vai ser chamada
    {
        Pisca();
    }

    public void InicioJogada() //Onclick para dar inicio a jogada do vil�o
    {
        _jogada = true;
        Debug.Log("Vil�o est� selecionando a casinha!");
    }

    public void Pisca()     //Fun��o de selecionar as casas
    {
        if (_jogada == true && _ocupado == false && _jogavel == true && _bloqueado == false) //S� ficar� disponivel para clicar se comprir essas condi��es
        {
            _selecionavel = true;
            _Botao.interactable = true;
            Debug.Log("disponivel");
            //_anim.Setbool("selecionando", _pisca);
        }
        else    //Caso n�o, n�o ficar� disponivel para ser bloqueado pelo vil�o
        {
            _selecionavel = false;
        }
    }

    public void Bloqueada()     //Fun��o da casinha bloqueada
    {
        if (_selecionavel == true)
        {
            //_anim.SetBool("Bloqueado", _bloqueado);
            _Botao.interactable = false;
            Debug.Log("Bloqueada, fim da jogada");
            _jogavel = false;
            _jogada = false;
        }
    }

    /*
    public bool SelecionandoBlock()
    {
        if (_ocupado)
        {
            ContinuaJogavel();
            return _selecionando;
        }
        else
        {
            _Botao.interactable = true;
            _selecionando = true;
            _anim.SetBool("Selecionando", _selecionando);
            return _selecionando;
        }   //Verificar se est� ocupado (tem que ser falso pra continuar)
            //Verificar se j� est� bloqueado(tem que ser falso pra continuar)
        
    }

    public void Bloqueado()
    {
        //Transformar em Ocupado por X rounds;
        //Bloqueado = true;
        _Botao.interactable = false;
        _selecionando = false;
        _anim.SetBool("Bloqueado", _bloqueado);
    }

    public void ContinuaJogavel()
    {
        _Botao.interactable = false;
        _selecionando = false;
        _jogavel = true;
        _anim.SetBool("Jogavel", _jogavel);
    }*/
}