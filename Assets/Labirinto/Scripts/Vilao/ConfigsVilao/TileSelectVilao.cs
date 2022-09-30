using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelectVilao : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Tilemap tiles; // Conjuntos de tiles(TileMap)
    [SerializeField] private GameObject trapVilao; // Prefab da armadilha do vilao
    [SerializeField] private GameObject mouseVilao; // objeto que está definido como mouse para auxiliar á spawn trap do vilao de possiveis erros
    private Tile tile; // Um Tile(uma célula)

    public Vector3Int LocationOfCell{get; private set;} // Localizacao de cada célula do meu TileMap
     
    void Update()
    {
        
        
        if(Input.GetMouseButtonDown(1) && GetEnableSpawnTrap() == true) // o GetEnableSpawnTrap() basicamente verifica se ja tem uma armadilha existente naquele tile, se tiver, retorna false, se nao, true
        {
                SpawnTrap();
        }
        else if(Input.GetMouseButtonDown(0))
        {
                PlaceParede();
        }    
        
    }

    void SpawnTrap()
    {
       
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Transforma a posicao do mouse da tela para a posicao do mouse no mundo da unity
        LocationOfCell = tiles.WorldToCell(mousePosWorld); // Basicamente vai retornar o valor de cada célula do timemap através da posicao do mouse
        
        if(tiles.GetTile(LocationOfCell) )
        {
            Vector3 posTrap = tiles.CellToWorld(LocationOfCell); // posicao das celulas no mundo da unity, que será onde a armadilha será spawnada

            Debug.Log("Tile encontrado na pos relacionado a Celula: "+LocationOfCell+" do TileMap Andar01");
            Debug.Log("Tile encontrado na pos relacionado ao mundo Unity: "+tiles.CellToWorld(LocationOfCell)+" do TileMap Andar01");
            
            Instantiate(trapVilao,new Vector3(posTrap.x, posTrap.y+0.25f, posTrap.z+2), Quaternion.identity); // os valores sao somados ao eixo y e z para corrigir o bug da posicao
            return;
        }
        else
        {
            Debug.Log("Tile nao encontrado no TileMap Andar01");
            return;
        }
        
    }

    bool GetEnableSpawnTrap()
    {
        return mouseVilao.GetComponent<MouseVilao>().EnableSpawnTrap; // pegando o valor da permissao ou negacao de spawnar trapVilao no tile
    }

    void PlaceParede()
    {
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        LocationOfCell = tiles.WorldToCell(mousePosWorld);

        if(tiles.GetTile(LocationOfCell))
        {
            Debug.Log("Posição: "+LocationOfCell);
            //inserir prefab do chão, encaixar o vilao nos turnos
            return;
        }
    }
    
     
    
    
        
    
    
}