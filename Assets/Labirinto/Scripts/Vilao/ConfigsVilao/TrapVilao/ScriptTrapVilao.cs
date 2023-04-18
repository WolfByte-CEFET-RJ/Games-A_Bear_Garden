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

                Destroy(gameObject); // Destruindo a trap
            }
       }
       
    }

    
}
