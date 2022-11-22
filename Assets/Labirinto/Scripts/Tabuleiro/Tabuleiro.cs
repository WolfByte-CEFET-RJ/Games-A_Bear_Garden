using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tabuleiro : MonoBehaviour
{
    public Dictionary<Vector3Int, TileLogic> tiles;// Dicionário de Posição
    public List<Floor> floors;// Andares do Labirinto
    public static Tabuleiro instance;

    public Grid grid;
    
    void Awake()
    {
        tiles = new Dictionary<Vector3Int, TileLogic>();
        instance = this;
        grid = GetComponent<Grid>();
    }

    public IEnumerator InitSequence(LoadState loadState)
    {
        yield return StartCoroutine(LoadFloors(loadState));
        yield return null; // Continua o carregamento do labirinto no proximo frame
        Debug.Log("Foram criados "+tiles.Count+" tiles");
        ShadowOrdering();
        yield return null;
    }
    IEnumerator LoadFloors(LoadState loadState)
    {
        for(int i=0; i<floors.Count; i++)
        {
            List<Vector3Int> floorTiles = floors[i].LoadTiles();
            yield return null;// Continua o carregamento do labirinto no proximo frame
            for(int j=0; j<floorTiles.Count; j++)
            {
                if(!tiles.ContainsKey(floorTiles[j]))
                {
                    CreateTile(floorTiles[j], floors[i]);// Posição e andar do Tile.
                }
            }
        }
    }

    public void CreateTile(Vector3Int pos, Floor floor)
    {
        Vector3 worldPos = grid.CellToWorld(pos);
        worldPos.y+= (floor.tilemap.tileAnchor.y/2)-0.5f;
        TileLogic tileLogic = new TileLogic(pos, worldPos, floor);
        tiles.Add(pos, tileLogic);
    }

    void ShadowOrdering()
    {
        foreach(TileLogic t in tiles.Values)
        {
            int floorIndex = floors.IndexOf(t.floor);
            floorIndex -= 2;// Se houver mais de 2 andares, a ordem de renderização é diferente

            if(floorIndex >=floors.Count || floorIndex <0)
            {
                continue;
            }
            Floor floorToCheck = floors[floorIndex];

            Vector3Int pos = t.pos;
            IsNECheck(floorToCheck,t ,pos+Vector3Int.right);// Caso o personagem esteja a esquerda ordena o tile da direita
            IsNECheck(floorToCheck,t ,pos+Vector3Int.up);// Caso o personagem esteja a baixo ordena o tile da cima
            IsNECheck(floorToCheck,t ,pos+Vector3Int.right+Vector3Int.up);// Caso o personagem esteja a nordeste ordena o tile da
        }
    }

    void IsNECheck(Floor floor, TileLogic t, Vector3Int NEPosition)
    {
        if(floor.tilemap.HasTile(NEPosition))
        {
            t.contentOrder = floor.order;// Ordena o tile do andar do personagem
        }
    }
    public static TileLogic GetTile(Vector3Int pos)
    {
        TileLogic tile = null;
        instance.tiles.TryGetValue(pos, out tile);
        return tile;
    }
}
