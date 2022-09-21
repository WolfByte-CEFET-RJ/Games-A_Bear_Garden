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
            Vector3 posTrap = tiles.CellToWorld(LocationOfCell); // posicao das celulas no mundo da unity, que será onde a armadilha será spawnada

            Debug.Log("Tile encontrado na pos relacionado a Celula: "+LocationOfCell+" do TileMap Andar01");
            Debug.Log("Tile encontrado na pos relacionado ao mundo Unity: "+tiles.CellToWorld(LocationOfCell)+" do TileMap Andar01");

            Instantiate(trapVilao,new Vector3(posTrap.x, posTrap.y+0.25f, posTrap.z+10), Quaternion.identity); // os valores sao somados ao eixo y e z para corrigir o bug da posicao
            return;
        }
        else
        {
            Debug.Log("Tile nao encontrado no TileMap Andar01");
            return;
        }
        
    }
}
