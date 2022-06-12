using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaInimiga : MonoBehaviour
{
    
    public Slider barraVida;                                            //Acessa a barra de vida na tela
    private float dano, vidaInimiga;                                           // dano = dano dos objetos, vida = vida do player
    [SerializeField]
    private TropasStats _stats;
    public TrocaDeCena _troca;

    void Start()
    {
        vidaInimiga = 100f;                                                    // Inicia com a vida cheia
        // ^ "100" trocado para "100f" pois os ataques (trabalhados no futuro) são float, portanto, a variável também é [Rodrigo]
        barraVida.value = vidaInimiga;                                         // Atribui o valor inicial da vida para a barra na tela
    }

   void Update()
    {
        barraVida.value = vidaInimiga;                                          // Atualiza o valor da vida
        if(vidaInimiga <= 0){
            _troca.TrocaCena();
        }
    }

    void OnCollisionEnter2D(Collision2D col){       //Rodrigo --> Função colisão modificada para extrair o ataque do script TropasStats e utilizar como dano sofrido
        if(col.gameObject.CompareTag("TropaBasica")){

            _stats.TropaComum();
            vidaInimiga -= _stats.trp_atk;

            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);            
            
        } else if(col.gameObject.CompareTag("SupertropaPapel")){
            _stats.Papel();
            vidaInimiga -= _stats.trp_atk;
            
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);

        } else if(col.gameObject.CompareTag("SupertropaPedra")){
            _stats.Pedra();
            vidaInimiga -= _stats.trp_atk;
            
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);

        } else if(col.gameObject.CompareTag("SupertropaTesoura")){
            _stats.Tesoura();
            vidaInimiga -= _stats.trp_atk;
            
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);
        }

    }
}
