using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; //Biblioteca do TileMaps

public class Floor : MonoBehaviour
{
    [SerializeField]
    public TilemapRenderer tilemapRenderer;
    public int order {get{return tilemapRenderer.sortingOrder;}}// Classifica a ordem dos Andares
   
    public int contentOrder;//Ordem das casas
    public Vector3Int minimoXY;
    public Vector3Int maximoXY;
    public Tilemap tilemap;

    void Awake()// Primeira Função antes do Start
    {
        tilemapRenderer = this.transform.GetComponent<TilemapRenderer>();
        tilemap = GetComponent<Tilemap>();
    }
    public List<Vector3Int> LoadTiles()
    {
        List<Vector3Int> tiles = new List<Vector3Int>();
        for(int i=minimoXY.x; i<=maximoXY.x; i++)
        {
            for(int j=minimoXY.y; j<=maximoXY.y; j++)
            {
                Vector3Int currentPos = new Vector3Int(i,j,0);
                if(tilemap.HasTile(currentPos))
                {
                    tiles.Add(currentPos);
                }
            }
        }
        return tiles;
    }
}
