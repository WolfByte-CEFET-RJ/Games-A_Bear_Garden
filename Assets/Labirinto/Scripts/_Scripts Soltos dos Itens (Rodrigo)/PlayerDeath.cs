using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    bool p1 = false, p2 = false, p3 = false;    //Rodrigo --> variáveis para checar quais heróis morreram e acabar o jogo
    

    
    public void RemoveTarget(string nome){  //Rodrigo --> função que remove cada unidade do jogo
        
       
        if(nome == "Jogador 3"){
            AudioController.DeathSound(0);//Joel --> Chama a animacao que interrompe a trilha sonora e toca a trilha de morte
            
            Destroy(GameObject.Find("Jogador 3"));   //Rodrigo --> remove o jogador 3 do mapa
            p3 = true;
        }
        else if(nome == "Jogador 2"){
            AudioController.DeathSound(0);
            Destroy(GameObject.Find("Jogador 2"));   //Rodrigo --> remove o jogador 2 do mapa
            p2 = true;
        }
        else if(nome == "Jogador 1"){
            AudioController.DeathSound(0);
            Destroy(GameObject.Find("Jogador 1"));   //Rodrigo --> remove o jogador 1 do mapa
            p1 = true;
        }
        else if(nome == "Vilao"){
            AudioController.DeathSound(1);
            Destroy(GameObject.Find("Vilao"));   //Rodrigo --> remove o vilão do mapa
            //acaba o game
        }

        if(p1 && p2 && p3){ Debug.Log("Teste"); }    //Rodrigo --> acaba o jogo (fazer no futuro)
        
    }
}
