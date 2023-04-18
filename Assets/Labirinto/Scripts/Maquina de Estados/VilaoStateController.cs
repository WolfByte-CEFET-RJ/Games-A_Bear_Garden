using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilaoStateController : State
{
    List<TileLogic> tiles;
    // ESTA VARIAVEL EnableSpawn E A CONDICAO DO OnFire ESTARÁ NESSE CODIGO TEMPORARIAMENTE ATÉ SER CRIADO UM ESTADO SOMENTE PARA SPAWNAR TRAP, QUE POSSA SER SELECIONADO NA HOLD BAR, SO PECO PARA NAO APAGAREM, DEIXEM COMENTADO TMJ!
    public static bool EnableSpawn{get; set;} // Eduardo --> Variavel que irá permitir a spawn da trap ou não

   public override void Enter()
   {
      base.Enter();
      EnableSpawn = true;
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
         
        
        if(Selector.instance.spriteRenderer.sortingOrder == 300 && EnableSpawn == true) // Eduardo --> Se o selector está na ordem de renderizacao do andar 01 e se o seletor nao estiver colidindo com uma trap, é possivel inicializar o turno de spawnar trap na posicao onde o selector está, esse código esta alocado temporariamente 
        {
           machine.ChangeTo<TrapVilaoState>();
        }

        /*if(Selector.instance.spriteRenderer.sortingOrder == 300 && EnableSpawnBlock == true) // Eduardo --> Se o selector está na ordem de renderizacao do andar 01 e se o seletor nao estiver colidindo com um bloco, é possivel inicializar o turno de spawnar bloco na posicao onde o selector está, esse código esta alocado temporariamente 
        {
           machine.ChangeTo<PathBlockedState>();
        }*/
        
      }
      else if(button==2)
      {
         machine.ChangeTo<ChooseActionState>();
      }
   }
}
