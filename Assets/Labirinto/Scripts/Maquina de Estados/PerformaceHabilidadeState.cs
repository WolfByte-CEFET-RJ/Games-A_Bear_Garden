using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformaceHabilidadeState : State
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(PerformaceHabilidadeSequencia());

    }
    IEnumerator PerformaceHabilidadeSequencia()
    {
        yield return null;
        Turnos.targets = Turnos.habilidade.GetTargets();
        yield return null;
        Turnos.habilidade.Efeito();
        yield return null;

        LogCombate.CheckAtiva();
        yield return new WaitForSeconds(1.5f);
        if(LogCombate.IsOver())
        {
            Debug.Log("Acabou o combate");
        }
        else
        {
            machine.ChangeTo<FinaldeTurnos>();
        }
    }
}
