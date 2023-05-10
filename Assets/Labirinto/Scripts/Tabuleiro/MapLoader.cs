using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLoader : MonoBehaviour
{
    public Unit unitPrefab;
    public Armadilha _trapV; // Eduardo --> Prefab trap vilao
    public BlockingBlock block; // Eduardo --> Prefab bloco que atrapalha o player
    
    //Jobs
    //Objetos do map
    //localização das unidades nesse map
    //quais unidades estão nesse mapa
    //
    public static MapLoader instance;
    GameObject holder;
    public List<Alianca> aliancas;

    void Awake()
    {
        instance = this;
        holder = new GameObject("Unidades de ação");
    }

    void Start()
    {
        holder.transform.parent = Tabuleiro.instance.transform;
        InitializeAliancas();
    }
    void InitializeAliancas() 
    {
        for(int i=0;i<aliancas.Count;i++)
        {
            aliancas[i].units = new List<Unit>();
        }
    }
    public void CriaUnidades()// 
    {
        Unit unit1 = CreateUnit(new Vector3Int(2, -4, 0), "Jogador 1"); // cria uma unidade no local 3,3,0 e add a lista de Unidades
        Unit unit2 = CreateUnit(new Vector3Int(3, -4, 0), "Jogador 2");
        Unit unit3 = CreateUnit(new Vector3Int(5, -1, 0), "Jogador 3");
        Unit unitV = CreateUnit(new Vector3Int(5, -2, 0), "Vilao");
        StateMachineController.instance.units.Add(unitV);
        StateMachineController.instance.units.Add(unit1);
        StateMachineController.instance.units.Add(unit2);
        StateMachineController.instance.units.Add(unit3);
        unit1.equipe = 0;// define o tipo de unidade a qual ela pertence
        unit2.equipe = 0;
        unit3.equipe = 0;
        unitV.equipe = 1;
        Debug.Log("Unidades Criadas");
    }

    public Unit CreateUnit(Vector3Int pos, string name)
    {
        TileLogic t = Tabuleiro.GetTile(pos);
        Unit unit = Instantiate(unitPrefab, t.worldPos, Quaternion.identity, holder.transform);
        unit.tile = t;
        unit.name = name;
        t.content = unit.gameObject;

        for(int i=0; i<unit.stats.stats.Count; i++)
        {
            unit.stats.stats[i].value = Random.Range(1,100);
        }
        return unit;
    }

}