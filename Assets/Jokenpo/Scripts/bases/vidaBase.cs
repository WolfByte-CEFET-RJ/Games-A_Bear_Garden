using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vidaBase : MonoBehaviour
{
    
    public Slider barraVida;                                            //Acessa a barra de vida na tela
    private int dano, vida;                                              // dano = dano dos objetos, vida = vida do player
    
    void Start()
    {
        vida = 100;                                                     // Inicia com a vida cheia
        barraVida.value = vida;                                         // Atribui o valor inicial da vida para a barra na tela
    }

   void Update()
    {
        barraVida.value = vida;                                          // Atualiza o valor da vida
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("TropaBasica")){
            dano = 10;
            vida = vida - dano;
            Destroy(col.gameObject);
            
        } else if(col.gameObject.CompareTag("SupertropaPapel")){
            dano = 10;
            vida = vida - dano;
            Destroy(col.gameObject);
            
        } else if(col.gameObject.CompareTag("SupertropaPedra")){
            dano = 5;
            vida = vida - dano;
            Destroy(col.gameObject);
            
        } else if(col.gameObject.CompareTag("SupertropaTesoura")){
            dano = 15;
            vida = vida - dano;
            Destroy(col.gameObject);
            
        }

    }
}
