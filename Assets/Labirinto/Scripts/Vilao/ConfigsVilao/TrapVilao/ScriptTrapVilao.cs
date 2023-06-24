using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTrapVilao : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "Unit")
       {

            if(col.gameObject.name != "Vilao" /*&& Turnos.hasMoved == true*/) // Condicao para que o vilao nao tome dano ao pisar na trap, a outra condicao comentada é a respeito de que o player so tome dano caso pare no mesmo tile da trap, preferi comentar pois nao acho essa a melhor ideia
            {
                //Fazer com que os players tomem dano

                Turnos.unit.hp -= 1;    //Rodrigo --> tira 1 de vida dos heróis
                UiPlayers.target = col.gameObject.GetComponent<Unit>();
                AudioController.ActiveTrapSound();
                Debug.Log("Vida do jogador: " + Turnos.unit.hp);
                Destroy(gameObject); // Destruindo a trap

            }
        }
    }

    
}
