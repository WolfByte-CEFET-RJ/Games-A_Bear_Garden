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
        Unit unit1 = CreateUnit(new Vector3Int(-3, 1, 0), "Jogador 1"); // cria uma unidade no local 3,3,0 e add a lista de Unidades
        Unit unit2 = CreateUnit(new Vector3Int(-4, 1, 0), "Jogador 2");
        Unit unit3 = CreateUnit(new Vector3Int(-4, 0, 0), "Jogador 3");
        Unit unitV = CreateUnit(new Vector3Int(-3, 0, 0), "Vilao");
        StateMachineController.instance.units.Add(unitV); // indice 0 na lista units
        AtribuiValores(unitV, '0');
        StateMachineController.instance.units.Add(unit1); // indice 1 na lista
        AtribuiValores(unit1, '1');
        StateMachineController.instance.units.Add(unit2); // indice 2 na lista
        AtribuiValores(unit2, '1');
        StateMachineController.instance.units.Add(unit3); // indice 3 na lista
        AtribuiValores(unit3, '1');

        Debug.Log("Unidades Criadas");
    }

    public void AtribuiValores(Unit _unidade, char _classe){
        //Rodrigo --> Método utilizado para atribuir os valores de equipe, ataque e vida às unidades dependendo se suas "classes" (herói ou vilão)
        if (_classe == '1'){
        //Rodrigo --> é um herói
        _unidade.equipe = '1';
        _unidade.atk = 1;
        _unidade.mana = 0;
        _unidade.hp = 4;
        }
        else if (_classe == '0'){
        //Rodrigo --> é um vilão
        _unidade.equipe = '0';
        _unidade.atk = 2;
        _unidade.mana = 0;
        _unidade.hp = 5;
        }

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