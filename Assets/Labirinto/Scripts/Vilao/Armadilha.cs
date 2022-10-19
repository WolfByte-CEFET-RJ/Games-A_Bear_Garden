using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour
{
    //Rodrigo --> Script responsável por atribuir valores específicos às armadilhas e auxiliar no spawn das mesmas
    public int dano = 5;    //Rodrigo --> valor do dano
    [HideInInspector] public TileLogic tile;// Onde a unidade consegue identificar onde está.
    
    void Awake()
    {
        //stats = GetComponentInChildren<Stats>();// informações será armazenada no stats do personagem no Objeto filho 
    }
}
