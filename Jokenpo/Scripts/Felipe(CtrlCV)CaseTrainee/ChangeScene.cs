using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [Header("Troca de Cena")]
    public CarregadorFase _carregadorFase;
    public string         _nomeDaCena;

    void Start()
    {
        
    }

    public void ChangeS()
    {
        _carregadorFase.Transicao(_nomeDaCena);
    }

    public void Sair ()
    {
        Application.Quit();
    }

    void Update()
    {
        
    }
}
