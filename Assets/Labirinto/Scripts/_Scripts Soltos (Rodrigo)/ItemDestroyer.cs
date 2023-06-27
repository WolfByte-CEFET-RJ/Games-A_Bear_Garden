using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    //Rodrigo --> Script para destruir o item coletável após a colisão com um jogador (a ser integrado com o script geral do Dudu)

    void OnTriggerEnter2D(Collider2D col){
        
        if(col.tag == "Jogador")    //Rodrigo --> caso seja possível inicializar as unidades com tags, este if previne bugs de colisão com possíveis outros objetos
            Destroy(this);

        //Destroy(this);            //Rodrigo --> caso contrário, apenas destruir
    }
}
