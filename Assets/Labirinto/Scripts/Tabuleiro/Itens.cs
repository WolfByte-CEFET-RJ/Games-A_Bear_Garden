using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Itens : MonoBehaviour
{
    [HideInInspector] public bool canAbility;       //Rodrigo --> variável tipo bool para checar se o HERÓI pode usar uma habilidade
    Unit unit;

    public static Itens instance;   
                                            //Neste script: criar uma lista dos tiles onde se encontram os itens e criar as lógicas de conceder mana 
                                            //Script de movimento: checar se o valor de "to" condiz com um item antes do LeanTween e chamar as lógicas após o movimento
    //Rodrigo --> Método Awake para setar os valores assim que o jogo for inicializado
    void Awake()
    {
        instance = this;
        canAbility = false;
        //unit = this.GetComponent<Unit>();
    }
    public List<Vector3Int> GetTilesItens()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        List<Vector3Int> itens = new List<Vector3Int>();//      <-- lista das posições

        BoundsInt bounds = tilemap.cellBounds; // reconhece os limites do Mapa

        foreach(var pos in bounds.allPositionsWithin)
        {
            if(tilemap.HasTile(pos))
            {
                //unit.SetStat(StatEnum.MP, 4);
                itens.Add(new Vector3Int(pos.x ,pos.y ,0));
                Debug.LogFormat("Tile ({0},{1}) é um item coletável",pos.x, pos.y);
            }
        }
        return itens;
    }

    public void giveMana(){
        //Unit unit = this.GetComponent<Unit>();    

        Debug.Log("O item foi pego!");
        /*
        //---Checar como aplicar as alianças---//        
        if(unit.alianca == 0){   //Rodrigo --> se o jogador for um dos heróis...
            canAbility = true;      //Rodrigo --> ...variável da habilidade se ativa
        }
            
        else if(unit.alianca == 1){   //Rodrigo --> Se o jogador for o vilão...
                //Rodrigo --> ...aumente 4 no valor da mana   //mudar o número após "+=" para adequar a quantidade de mana ganha
        }*/
        //-------------------------------------//
    }
}
