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

        MapLoader.instance.CriaUnidades();
        yield return null;
        InitialTurnOrdering();
        UnitAlianças();
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
    void UnitAlianças()// Verifica todos as unidades e atribui as alianças
    {
        for(int i=0;i<machine.units.Count; i++)
        {
            SetUnitAliança(machine.units[i]);
        }
    }
    void SetUnitAliança(Unit unit)//Atribui a aliança a qual a unidade pertence 
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
}