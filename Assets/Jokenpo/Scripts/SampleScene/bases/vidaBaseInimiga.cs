using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaBaseInimiga : MonoBehaviour
{
   public Slider barraVidaI;                                            //Acessa a barra de vida na tela
    private float dano, vidaI;                                           // dano = dano dos objetos, vida = vida do player
    [SerializeField]
    private TropasStats _stats;

    void Start()
    {
        vidaI = 100f;                                                    // Inicia com a vida cheia
        // ^ "100" trocado para "100f" pois os ataques (trabalhados no futuro) são float, portanto, a variável também é [Rodrigo]
        barraVidaI.value = vidaI;                                         // Atribui o valor inicial da vida para a barra na tela
        
    }

   void Update()
    {
        barraVidaI.value = vidaI;                                          // Atualiza o valor da vida
        PlayerPrefs.SetFloat("vida_inimiga", vidaI);
    }

    void OnCollisionEnter2D(Collision2D col){       //Rodrigo --> Função colisão modificada para extrair o ataque do script TropasStats e utilizar como dano sofrido
        if(col.gameObject.CompareTag("TropaBasica")){

            _stats.TropaComum();
            vidaI -= _stats.trp_atk;

            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);            
            
        } else if(col.gameObject.CompareTag("SupertropaPapel")){
            _stats.Papel();
            vidaI -= _stats.trp_atk;
            
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);

        } else if(col.gameObject.CompareTag("SupertropaPedra")){
            _stats.Pedra();
            vidaI -= _stats.trp_atk;
            
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);

        } else if(col.gameObject.CompareTag("SupertropaTesoura")){
            _stats.Tesoura();
            vidaI -= _stats.trp_atk;
            
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);
        }
    }
}
