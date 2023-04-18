using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColecionavel : MonoBehaviour
{
    PlayerScriptGeral _player;   //Rodrigo --> Variável para dialogar com o script de monitoramento do jogador que efetuar a colisão (especificamente a equipe dele)
    bool condition = true;      //Rodrigo --> Variável para restringir o aumento de mana a uma vez

    
    void Update()
    {
        // Debug.Log("Variavel Turnos.hasMoved: " + Turnos.hasMoved);
    }


    private void OnTriggerStay2D(Collider2D col) {
        if(col.gameObject.tag == "Unit")// se o item colecionavel colidir com uma unidade e essa unidade estiver com a velocidade 0, executará um código
        {
            _player = col.gameObject.GetComponent<PlayerScriptGeral>(); //Rodrigo --> Identifica o jogador durante a colisão        

           // Debug.Log("Velocidade Unit: "+ col.gameObject.GetComponent<Rigidbody2D>().velocity);
            
            
            if(Turnos.hasMoved == true)
            {
                if(_player.equipe == '0'){  //Rodrigo --> Adiciona 20 de mana se for o vilão
                    while(condition)
                    {
                        _player.mana += 20;
                        condition = false;
                    }
                }
                else if(_player.equipe == '1'){ //Rodrigo --> Adiciona 10 de mana se for o herói
                    while(condition)
                    {
                        _player.mana += 10;
                        condition = false;
                    }                
                }
                //Debug.Log("COLIDIUU");
                Destroy(this.gameObject);
                SpawnerItem.CanSpawn = true;
            }            
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        condition = true;   //Rodrigo --> Libera a variável de condição após a colisão acaba
    }
}
