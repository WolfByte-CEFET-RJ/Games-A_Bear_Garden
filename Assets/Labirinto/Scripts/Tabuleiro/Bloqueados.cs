using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bloqueados : MonoBehaviour
{
    public static Bloqueados instance;
    void Awake()
    {
        instance = this;
        GetComponent<TilemapRenderer>().enabled = false;
    }
    public List<Vector3Int> GetTilesBloqueados()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        List<Vector3Int> bloqueados = new List<Vector3Int>();

        BoundsInt bounds = tilemap.cellBounds; // reconhece os limites do Mapa

        foreach(var pos in bounds.allPositionsWithin)
        {
            if(tilemap.HasTile(pos))
            {
                bloqueados.Add(new Vector3Int(pos.x ,pos.y ,0));
                Debug.LogFormat("Tile ({0},{1}) está bloqueado",pos.x, pos.y);
            }
        }
        return bloqueados;
    }
}
