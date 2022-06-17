using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloqueandoCasa : MonoBehaviour
{
    [Header("Casinhas")]
    public bool _bloqueado; //Variavel da casinha bloqueada
    public bool _jogavel;   //variavel da casnha jogavel
    public bool _ocupado;   //variavel da casinha ocupada pelo player
    public bool _selecionavel;  //variavel da casinha disponivel para ser bloqueada
    public bool _jogada;    //variavel da jogada do vilao
    public Button _Botao;   //variavel do Botao da casinha
    public Animator    _anim;      //Variavel para chamar as animacoes


    public void Update()    //Checa se a funcao Pisca vai ser chamada
    {
        Pisca();
    }

    public void InicioJogada() //Onclick para dar inicio a jogada do vilao
    {
        _jogada = true;
        Debug.Log("Vilao esta selecionando a casinha!");
    }

    public void Pisca()     //Funcao de selecionar as casas
    {
        if (_jogada == true && _ocupado == false && _jogavel == true && _bloqueado == false) //So ficara disponivel para clicar se comprir essas condicoes
        {
            _selecionavel = true;
            _Botao.interactable = true;
            Debug.Log("disponivel");
            _anim.SetBool("_selecionavel", _selecionavel);
        }
        else    //Caso nao, nao ficara disponivel para ser bloqueado pelo vilao
        {
            _selecionavel = false;
        }
    }

    public void Bloqueada()     //Funcao da casinha bloqueada
    {
        if (_selecionavel == true)
        {
            _bloqueado = true;
            _anim.SetBool("_selecionavel", _selecionavel = false);
            _anim.SetBool("_bloqueado", _bloqueado);
            _Botao.interactable = false;
            Debug.Log("Bloqueada, fim da jogada");
            _selecionavel = false;
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