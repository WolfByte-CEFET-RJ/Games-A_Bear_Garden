using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaController : MonoBehaviour
{
    //Script feito pela Natty
    public GameObject[] objetos; //Lista onde adiciona os GamesObjects para serem chamados
    public int[] ordem; // Ordem que cada elemento vai receber

    private int indiceAtual = 0; //Vai começar pelo zero

    private void Start()
    {
        Invoke("AtivarProximoObjeto", 1f); // ativa o primeiro objeto depois de 1 segundo
    }

    private void AtivarProximoObjeto()
    {
        if (indiceAtual < objetos.Length)
        {
            int indiceObjetoAtual = ordem[indiceAtual]; 
            objetos[indiceObjetoAtual].SetActive(true); //Muda o estado para ativado
            indiceAtual++;
            Invoke("AtivarProximoObjeto", 1f); // chama o próximo objeto depois de 1 segundo
        }
    }
}