using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelectionState : State
{
    // ESTA VARIAVEL EnableSpawn E A CONDICAO DO OnFire ESTARÁ NESSE CODIGO TEMPORARIAMENTE ATÉ SER CRIADO UM ESTADO SOMENTE PARA SPAWNAR TRAP, QUE POSSA SER SELECIONADO NA HOLD BAR, SO PECO PARA NAO APAGAREM, DEIXEM COMENTADO TMJ!
   // public static bool EnableSpawn{get; set;} // Eduardo --> Variavel que irá permitir a spawn da trap ou não
    public override void Enter()
   {
      base.Enter();
      //EnableSpawn = true;
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
        machine.ChangeTo<MoveSequenceState>();
        
        /*if(Selector.instance.spriteRenderer.sortingOrder == 300 && EnableSpawn == true) // Eduardo --> Se o selector está na ordem de renderizacao do andar 01 e se o seletor nao estiver colidindo com uma trap, é possivel inicializar o turno de spawnar trap na posicao onde o selector está, esse código esta alocado temporariamente 
        {
           machine.ChangeTo<TurnoDoVilao>();
        }*/
        
      }
      else if(button==2)
      {
         machine.ChangeTo<ChooseActionState>();
      }
   }
}
