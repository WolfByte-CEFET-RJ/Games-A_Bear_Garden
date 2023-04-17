using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropasScriptGeral : MonoBehaviour
{
    //Script para gerenciar todas as funções das tropas (também relacionada com os scripts de movimento porém, )
    private TropasStats _stats;
    [HideInInspector]
    public float vida;
    [HideInInspector]
    public float ataque;
    [HideInInspector]
    public float speed;

    private AudioClip actualAttack;
    private AudioSource AS;
    /*  Joel ---> Cola para a logica do som do ataque da tropa
    GetSFX(0) -> Comum
    GetSFX(1) -> papel
    GetSFX(2) -> pedra
    GetSFX(3) -> tesoura
    */

    void Awake()    //Rodrigo --> inicialização dos stats da tropa 
    {
        _stats = FindObjectOfType<vidaBase>().GetComponent<TropasStats>();//Joel ---> Refatoracao do sistema envolvendo esse script: Em vez de todas as tropas possuirem e acessarem ele de si mesmas,
        //agora esse script estara apenas nas bases, e por esse comando, todas as tropas poderao acessar de la. O primeiro Find e pra garantir de que estou olhando para uma base, procurando um obj com 
        //VidaBase anexado. Depois, a partir desse obj, pego o script TropasStats dele.
        if(this.gameObject.tag == "TropaBasica")
        {
            _stats.TropaComum();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
            actualAttack = _stats.GetSFX(0);
        }
        else if(this.gameObject.tag == "SupertropaPapel")
        {
            _stats.Papel();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
            actualAttack = _stats.GetSFX(1);
        }
        else if(this.gameObject.tag == "SupertropaPedra")
        {
            _stats.Pedra();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
            actualAttack = actualAttack = _stats.GetSFX(2);
        }
        else if(this.gameObject.tag == "SupertropaTesoura")
        {
            _stats.Tesoura();
            vida = _stats.trp_vida;
            ataque = _stats.trp_atk;
            speed = _stats.trp_spd;
            actualAttack = actualAttack = _stats.GetSFX(3);
        }
        AS = GetComponent<AudioSource>();

    }
    
    void FixedUpdate()
    {
        
        
    }
    private bool created = false;
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
        if(this.gameObject.tag == "TropaBasica" && !created && (other.gameObject.tag == "SupertropaPapel" || other.gameObject.tag == "SupertropaPedra" || other.gameObject.tag == "SupertropaTesoura"))
        {
            transform.position -= Vector3.right * 1.5f;
            created = true;
        }
    }

    IEnumerator Death()//Joel--->Redefinicao da morte de uma tropa, pra conseguir executar o som de ataque
    {
        AS.PlayOneShot(actualAttack);
        created = true;
        //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(actualAttack.length);//*+*
        Destroy(gameObject);
    }
}

//*+*Destruir a tropa apenas no fim do som de ataque. Se preciso apos implementar as animacoes,
//Substituir esse parametro pela duracao da animacao do ataque