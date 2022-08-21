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

        StateMachineController.instance.ChangeTo<ChooseActionState>();
    }
    void InitialTurnOrdering()
    {
        int Primeiro = Random.Range(0, machine.units.Count);
        Turnos.hasActed = false;
        Turnos.hasMoved = false;
        Turnos.unit = machine.units[Primeiro];
    }
}
