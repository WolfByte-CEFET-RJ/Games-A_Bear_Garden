using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaBaseAmiga : MonoBehaviour
{
    public Slider barraVidaA;                                            //Acessa a barra de vida na tela
    private float dano, vidaA;                                           // dano = dano dos objetos, vida = vida do player
    [SerializeField]
    private TropasStats _stats;

    void Start()
    {
        vidaA = 100f;                                                    // Inicia com a vida cheia
        // ^ "100" trocado para "100f" pois os ataques (trabalhados no futuro) são float, portanto, a variável também é [Rodrigo]
        barraVidaA.value = vidaA;                                         // Atribui o valor inicial da vida para a barra na tela
        
    }

   void Update()
    {
        barraVidaA.value = vidaA;                                          // Atualiza o valor da vida
        PlayerPrefs.SetFloat("vida_amiga", vidaA);
    }

    void OnCollisionEnter2D(Collision2D col){       //Rodrigo --> Função colisão modificada para extrair o ataque do script TropasStats e utilizar como dano sofrido
        if(col.gameObject.CompareTag("TropaBasica")){

            _stats.TropaComum();
            vidaA -= _stats.trp_atk;

            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);            
            
        } else if(col.gameObject.CompareTag("SupertropaPapel")){
            _stats.Papel();
            vidaA -= _stats.trp_atk;
            
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);

        } else if(col.gameObject.CompareTag("SupertropaPedra")){
            _stats.Pedra();
            vidaA -= _stats.trp_atk;
            
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);

        } else if(col.gameObject.CompareTag("SupertropaTesoura")){
            _stats.Tesoura();
            vidaA -= _stats.trp_atk;
            
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);
        }
    }
}
