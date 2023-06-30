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
        Animator anim = Turnos.unit.GetComponentInChildren<Animator>();
        if (anim != null)
            AnimController.SetTrigger(anim, "atk");
        AudioController.AttackSound(Turnos.unit.name);
        Turnos.habilidade.Efeito();
        yield return null;
        //LogCombate.CheckAtiva();
        yield return new WaitForSeconds(1.5f);
        machine.ChangeTo<FinaldeTurnos>();
        
        yield return null;
    }
}
