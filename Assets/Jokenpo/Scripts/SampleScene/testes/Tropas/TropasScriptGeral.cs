using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropasScriptGeral : MonoBehaviour
{
    //Script para gerenciar todas as funções das tropas (também relacionada com os scripts de movimento porém, )
    [SerializeField]
    private TropasStats _stats;
    [HideInInspector]
    public float vida;
    [HideInInspector]
    public float ataque;
    [HideInInspector]
    public float speed;

    void Awake()    //Rodrigo --> inicialização dos stats da tropa 
    {
        if(this.gameObject.tag == "TropaBasica")
        {
            _stats.TropaComum();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
        }
        else if(this.gameObject.tag == "SupertropaPapel")
        {
            _stats.Papel();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
        }
        else if(this.gameObject.tag == "SupertropaPedra")
        {
            _stats.Pedra();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
        }
        else if(this.gameObject.tag == "SupertropaTesoura")
        {
            _stats.Tesoura();
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

    void OnCollisionEnter2D(Collision2D other)      //Rodrigo --> Detecta a colisão com uma tropa qualquer e destrói esta tropa (esquema de vidas para  o futuro) + vida vai a 0 após colidir com uma base
    {
        if(other.gameObject.tag == "TropaBasica" || other.gameObject.tag == "SupertropaPapel" || other.gameObject.tag == "SupertropaPedra" || other.gameObject.tag == "SupertropaTesoura")
        //Rodrigo --> introduzir o conceito de pegar os ataques
        {
            vida--;
        }

        if(other.gameObject.tag == "baseAmiga" || other.gameObject.tag == "baseInimiga")
        {
            vida = 0;
        }
    }
}
