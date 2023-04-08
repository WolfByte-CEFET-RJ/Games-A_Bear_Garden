using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vidaBase : MonoBehaviour
{
    
    public Slider barraVida;                                            //Acessa a barra de vida na tela
    private float vida;                                           // dano = dano dos objetos, vida = vida do player
    private float vidaMax;
    [SerializeField]
    private TropasStats _stats;

    [SerializeField] private bool isPlayer;

    public float Vida { get => vida; private set => vida = value; }

    void Start()
    {
        vidaMax = vida = 40f;                                                    // Inicia com a vida cheia
        // ^ "100" trocado para "100f" pois os ataques (trabalhados no futuro) são float, portanto, a variável também é [Rodrigo]
        barraVida.value = 1;                                         // Atribui o valor inicial da vida para a barra na tela
    }

   //void Update()
   // {
   //     barraVida.value = vida / vidaMax;                                          // Atualiza o valor da vida
   // }

    void OnCollisionEnter2D(Collision2D col){       //Rodrigo --> Função colisão modificada para extrair o ataque do script TropasStats e utilizar como dano sofrido
        if(col.gameObject.CompareTag("TropaBasica")){

            _stats.TropaComum();
            vida -= _stats.trp_atk;
            barraVida.value = vida / vidaMax;
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);            

        } else if(col.gameObject.CompareTag("SupertropaPapel")){
            _stats.Papel();
            vida -= _stats.trp_atk;
            barraVida.value = vida / vidaMax;
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);

        } else if(col.gameObject.CompareTag("SupertropaPedra")){
            _stats.Pedra();
            vida -= _stats.trp_atk;
            barraVida.value = vida / vidaMax;
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);

        } else if(col.gameObject.CompareTag("SupertropaTesoura")){
            _stats.Tesoura();
            vida -= _stats.trp_atk;
            barraVida.value = vida / vidaMax;
            //dano = _stats.trp_atk;        //Rodrigo --> testes para averiguar o funcionamento
            //Debug.Log("dano sofrido: " + dano);
            //Debug.Log("vida da base: " + vida);
        }
        if(vida <= 0)
        {
            if (isPlayer)
                VictoryControl.instance.PlayerVictory();
            else
                VictoryControl.instance.BossVictory();
        }
        /*      VERSÃO DO FELIPE
        void OnCollisionEnter2D(Collision2D col){
            if(col.gameObject.CompareTag("TropaBasica")){
                dano = 10;
                vida = vida - dano;
                Destroy(col.gameObject);
            }
            else if(col.gameObject.CompareTag("SupertropaPapel")){
                dano = 10;
                vida = vida - dano;
                Destroy(col.gameObject);
            }
            else if(col.gameObject.CompareTag("SupertropaPedra")){
                dano = 5;
                vida = vida - dano;
                Destroy(col.gameObject);
            }
            else if(col.gameObject.CompareTag("SupertropaTesoura")){
                dano = 15;
                vida = vida - dano;
                Destroy(col.gameObject);
            }
        }
        */

    }
}
