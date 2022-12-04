using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadeTargetSate : State
{
    public override void Enter()
   {
      base.Enter();
      //EnableSpawn = true;
      //EnableSpawnBlock = true;
      inputs.OnMove+=OnMoveTileSelector;
      inputs.OnFire+=OnFire;
   }
   public override void Exit()
   {
      base.Exit();
      inputs.OnMove-=OnMoveTileSelector;
      inputs.OnFire-=OnFire;
   }
   void OnFire(object sender, object args)
   {
        int button = (int)args;
        if(button==1)
        {  
            if(Turnos.habilidade.ValidaçaoTarget())
            {
                machine.ChangeTo<PerformaceHabilidadeState>();
            }
        }
        else if(button==2)
        {
          machine.ChangeTo<SeleçaoHabilidadeState>();
        }
    }
}
