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

    [Header("Sounds Config")]
    [SerializeField] private AudioClip[] attacks;
    private AudioClip actualAttack;
    private AudioSource AS;
    /*  Joel ---> Cola para a logica do som do ataque da tropa
    attacks[0] -> Comum
    attacks[1] -> papel
    attacks[2] -> pedra
    attacks[3] -> tesoura
    */

    void Awake()    //Rodrigo --> inicialização dos stats da tropa 
    {
        if(this.gameObject.tag == "TropaBasica")
        {
            _stats.TropaComum();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
            actualAttack = attacks[0];
        }
        else if(this.gameObject.tag == "SupertropaPapel")
        {
            _stats.Papel();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
            actualAttack = attacks[1];
        }
        else if(this.gameObject.tag == "SupertropaPedra")
        {
            _stats.Pedra();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
            actualAttack = attacks[2];
        }
        else if(this.gameObject.tag == "SupertropaTesoura")
        {
            _stats.Tesoura();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
            actualAttack = attacks[3];
        }
        AS = GetComponent<AudioSource>();

    }

    void Start()
    {
        //nothing
    }
    
    void FixedUpdate()
    {
        
        
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
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()//Joel--->Redefinicao da morte de uma tropa, pra conseguir executar o som de ataque
    {
        AS.PlayOneShot(actualAttack);
        //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(actualAttack.length);//*+*
        Destroy(gameObject);
    }
}

//*+*Destruir a tropa apenas no fim do som de ataque. Se preciso apos implementar as animacoes,
//Substituir esse parametro pela duracao da animacao do ataque