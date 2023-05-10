using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadeTargetSate : State
{

    [SerializeField] Habilidade habilidadeSelected;


    public override void Enter()
   {
      base.Enter();
      inputs.OnMove+=OnMoveTileSelector;
      inputs.OnFire+=OnFire;
      CheckHabilidades();
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
            if(Turnos.habilidade.ValidaçaoTarget() && habilidadeSelected.EstaUsando())
            {
                machine.ChangeTo<PerformaceHabilidadeState>();
            }
        }
        else if(button==2)
        {
          machine.ChangeTo<ChooseActionState>();
        }
    }

    void CheckHabilidades()
    {
        GameObject habilidadeObject = GameObject.FindGameObjectWithTag("Habilidade Ataque");
        habilidadeSelected = habilidadeObject.GetComponent<Habilidade>();

        if(habilidadeSelected.EstaUsando())
        {
            Debug.Log("Usando "+habilidadeSelected.name);
            Turnos.habilidade = habilidadeSelected;
        }
    }
}


