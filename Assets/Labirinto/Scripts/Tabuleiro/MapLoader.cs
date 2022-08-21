using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapLoader : MonoBehaviour
{
    public Unit unitPrefab;
    //Jobs
    //Objetos do map
    //localização das unidades nesse map
    //quais unidades estão nesse mapa
    //
    public static MapLoader instance;
    GameObject holder;
    void Awake()
    {
        instance = this;
        holder = new GameObject("Unidades de ação");
    }

    void Start()
    {
        holder.transform.parent = Tabuleiro.instance.transform;
    }
    public void CriaUnidades()
    {
        Unit unit1 = CreateUnit(new Vector3Int(3, 3, 0), "Jogador 1"); // cria uma unidade no local 3,3,0 e add a lista de Unidades
        Unit unit2 = CreateUnit(new Vector3Int(-1, -1, 0), "Inimigo");
        StateMachineController.instance.units.Add(unit1);
        StateMachineController.instance.units.Add(unit2);
        unit1.equipes = 0;// define o tipo de unidade a qual ela pertence
        unit2.equipes = 1;
    }

    public Unit CreateUnit(Vector3Int pos, string name)
    {
        TileLogic t = Tabuleiro.GetTile(pos);
        Unit unit = Instantiate(unitPrefab, t.worldPos, Quaternion.identity, holder.transform);
        unit.tile = t;
        unit.name = name;
        return unit;
    }
}