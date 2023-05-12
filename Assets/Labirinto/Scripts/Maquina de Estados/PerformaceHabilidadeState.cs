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
        Turnos.habilidade.Efeito();
        yield return null;
        LogCombate.CheckAtiva();
        yield return new WaitForSeconds(1.5f);
        machine.ChangeTo<FinaldeTurnos>();
        
        yield return null;
    }
}
