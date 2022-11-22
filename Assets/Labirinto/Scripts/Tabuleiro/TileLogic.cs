using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic // Eduardo--> A classse TileLogic representa um objeto Tile e suas respectivas informacoes: cellPos, worldPos e floor
{
    public Vector3Int pos; //Posição de Tabuleiro
    
    public Vector3 worldPos; // Posição no Mundo na Unity
    public GameObject content; // Objeto que bloqueia a posição do Personagem
    public Floor floor;
    public int contentOrder;

    //public TileType tileType; // Referencia para se ter vários Tiles como água. montanha... Onde o Personagem não pode se mover

    public TileLogic(){}
    public TileLogic(Vector3Int cellPos, Vector3 worldPosition, Floor tempFloor)
    {
        pos = cellPos;
        worldPos = worldPosition;
        floor = tempFloor;
        contentOrder = tempFloor.contentOrder;
    }
    public static TileLogic Create(Vector3Int cellPos, Vector3 worldPosition, Floor tempFloor)
    {
        TileLogic tileLogic = new TileLogic(cellPos,worldPosition,tempFloor);
        return tileLogic;
    }
}

