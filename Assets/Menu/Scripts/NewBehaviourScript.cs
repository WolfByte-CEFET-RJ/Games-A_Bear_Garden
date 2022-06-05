using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator _anim;
    public Button   _Botao;
    public bool     _selecionando;
    public bool     _jogavel = false;
    public bool     _bloqueado;

    public void Update()
    {

        //if (_selecionando) {}
    }

    public void SelecionandoBlock()
    {
        _Botao.interactable = true;
        _selecionando = true;
        _anim.SetBool("Selecionando", _selecionando);
    }

    public void Bloqueado()
    {
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

    }
}
