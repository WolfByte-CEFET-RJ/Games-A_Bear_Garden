using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : State
{
    public override void Enter()
    {
       StartCoroutine(LoadSequence());
    }

    IEnumerator LoadSequence()
    {
        yield return  StartCoroutine(Tabuleiro.instance.InitSequence(this));
        Debug.Log("Entrou no LoadState");
        yield return null; // Continua o carregamento do labirinto no proximo frame
        yield return StartCoroutine(LoadAnimacoes());
        yield return null;
        MapLoader.instance.CriaUnidades();
        yield return null;
        InitialTurnOrdering();
        yield return null;
        UnitAliancas();
        yield return null;
        List<Vector3Int> bloqueados = Bloqueados.instance.GetTilesBloqueados();
        yield return null;
        SetBloqueados(bloqueados);
        yield return null;

        StateMachineController.instance.ChangeTo<ComeçodeTurnos>();
    }
    void InitialTurnOrdering()
    {
        for(int i=0;i<machine.units.Count; i++)
        {
            machine.units[i].chargeTime = 100-machine.units[i].GetStat(StatEnum.SPEED);// Controla os turnos de Cada Unidade, Ordem do turno.
            machine.units[i].ativa = true;
        }
    }
    void UnitAliancas()// Verifica todos as unidades e atribui as alianças
    {
        for(int i=0;i<machine.units.Count; i++)
        {
            SetUnitAlianca(machine.units[i]);
        }
    }
    void SetUnitAlianca(Unit unit)//Atribui a aliança a qual a unidade pertence 
    {
        for(int i=0;i<MapLoader.instance.aliancas.Count; i++)
        {
            if(MapLoader.instance.aliancas[i].equipes.Contains(unit.equipe))
            {
                MapLoader.instance.aliancas[i].units.Add(unit);
                unit.alianca = i;
                return;
            }
        }
    }
    void SetBloqueados(List<Vector3Int> bloqueados)
    {
        foreach(Vector3Int pos in bloqueados)
        {
            TileLogic t = Tabuleiro.GetTile(pos);
            t.content = Bloqueados.instance.gameObject;
        }
    }
    IEnumerator LoadAnimacoes()
    {
        SpriteLoader[] loaders = SpriteLoader.holder.GetComponentsInChildren<SpriteLoader>();
        foreach(SpriteLoader loader in loaders)
        {
            yield return loader.Load();
        }
    }
}