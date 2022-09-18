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

        StateMachineController.instance.ChangeTo<ComeçodeTurnos>();
    }
    void InitialTurnOrdering()
    {
        for(int i=0;i<machine.units.Count; i++)
        {
            machine.units[i].chargeTime = 100-machine.units[i].GetStat(StatEnum.SPEED);
        }
    }
}
