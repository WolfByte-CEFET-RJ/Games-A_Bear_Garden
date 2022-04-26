using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropasScriptGeral : MonoBehaviour
{
    //Script para gerenciar todas as funções das tropas (também relacionada com os scripts de movimento porém, )
    TropasStats _stats;
    [HideInInspector]
    public float vida;
    [HideInInspector]
    public float ataque;
    [HideInInspector]
    public float speed;

    void Awake()    //Rodrigo --> inicialização dos stats da tropa 
    {
        //Rodrigo --> inserir futuramente um if para cada tipo de tropa
        _stats = new TropasStats();
        if(this.gameObject.tag == "TropaBasica")
        {
            _stats.TropaComum();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
        }        

    }

    void Start()
    {
        //nothing
    }
    
    void FixedUpdate()
    {
        if(vida == 0)
        {
            Destroy(gameObject);
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)      //Rodrigo <-- Detecta a colisão com uma tropa básica e destrói a tropa (esquema de vidas para  o futuro)
    {
        if(other.gameObject.tag == "TropaBasica") //Rodrigo --> introduzir as outras tags no futuro
        {
            vida--;
        }
        //Rodrigo --> outras tags estarão futuramente aqui em elses
    }
}
