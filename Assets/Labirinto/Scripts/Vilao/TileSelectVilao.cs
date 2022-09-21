using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelectVilao : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Tilemap tiles; // Conjuntos de tiles(TileMap)
    [SerializeField] private GameObject trapVilao; // Prefab da armadilha do vilao
    private Tile tile; // Um Tile(uma célula)

    public Vector3Int LocationOfCell{get; private set;} // Localizacao de cada célula do meu TileMap

    
    void Update()
    {

        if(Input.GetMouseButtonDown(1))
        {
            GetT();
        }
        
    }

    void GetT()
    {
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Transforma a posicao do mouse da tela para a posicao do mouse no mundo da unity
        LocationOfCell = tiles.WorldToCell(mousePosWorld); // Basicamente vai retornar o valor de cada célula do timemap através da posicao do mouse

        
        if(tiles.GetTile(LocationOfCell) )
        {
            
            Debug.Log("Tile encontrado na pos: "+LocationOfCell+" do TileMap Andar01");
            Debug.Log("Tile encontrado na pos: "+tiles.CellToWorld(LocationOfCell)+" do TileMap Andar01");
            Instantiate(trapVilao,tiles.CellToWorld(LocationOfCell), Quaternion.identity);
            return;
        }
        else
        {
            Debug.Log("Tile nao encontrado no TileMap Andar01");
            return;
        }
        
    }
}
