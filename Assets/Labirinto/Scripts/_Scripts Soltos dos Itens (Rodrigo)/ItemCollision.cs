  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    /*//Rodrigo --> Script por jogador, checa se um item foi pego e garante o uso de uma habilidade (para os heróis) ou fornece mana (para o vilão)
    
    [HideInInspector] public bool canAbility;       //Rodrigo --> variável tipo bool para checar se o HERÓI pode usar uma habilidade
    //[HideInInspector] public int _canAbility;       //Rodrigo --> variável tipo int para contabilizar quantas vezes o HERÓI pode usar uma habilidade

    //Rodrigo --> Método Awake para setar os valores assim que o jogo for inicializado
    void Awake()
    {
        canAbility = false;
        //_canAbility = 0;
    }

    void OnTriggernEnter2D(Collider2D col){    //Rodrigo --> função de colisão, neste caso, com o item coletável

        Unit unit = this.GetComponent<Unit>();
        
        if(col.CompareTag("Item")){      //Rodrigo --> if para checar se o jogador coletou (colidiu com) o item

            if(unit.alianca == 0){   //Rodrigo --> se o jogador for um dos heróis...
                canAbility = true;      //Rodrigo --> ...variável da habilidade se ativa
                //_canAbility++;
              }
            
          else if(unit.aliana == 1){   //Rodrigo --> Se o jogador for o vilão...
                unit.SetStat(StatEnum.MP, 4);    //Rodrigo --> ...aumente 4 no valor da mana   //mudar o número após "+=" para adequar a quantidade de mana ganha
            }
        }
    }*/
}