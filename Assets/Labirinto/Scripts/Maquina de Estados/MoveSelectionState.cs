using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelectionState : State
{
<<<<<<< HEAD
<<<<<<< Updated upstream
    // ESTA VARIAVEL EnableSpawn E A CONDICAO DO OnFire ESTARÁ NESSE CODIGO TEMPORARIAMENTE ATÉ SER CRIADO UM ESTADO SOMENTE PARA SPAWNAR TRAP, QUE POSSA SER SELECIONADO NA HOLD BAR, SO PECO PARA NAO APAGAREM, DEIXEM COMENTADO TMJ!
<<<<<<< HEAD
   // public static bool EnableSpawn{get; set;} // Eduardo --> Variavel que irá permitir a spawn da trap ou não
=======
   public static bool EnableSpawn{get; set;} // Eduardo --> Variavel que irá permitir a spawn da trap ou não
>>>>>>> parent of ea90abd (update Comentando os codigos)
    //public static bool EnableSpawnBlock{get; set;} // Eduardo --> Variavel que irá permitir a spawn do Block ou não
=======
>>>>>>> parent of 97a30b4 (update Criacao de spawnar trap dentro da maquina de estados com todos os detalhes corretos)
    public override void Enter()
=======
   // ESTA VARIAVEL EnableSpawn E A CONDICAO DO OnFire ESTARÁ NESSE CODIGO TEMPORARIAMENTE ATÉ SER CRIADO UM ESTADO SOMENTE PARA SPAWNAR TRAP, QUE POSSA SER SELECIONADO NA HOLD BAR, SO PECO PARA NAO APAGAREM, DEIXEM COMENTADO TMJ!
   //public static bool EnableSpawn{get; set;} // Eduardo --> Variavel que irá permitir a spawn da trap ou não
   //public static bool EnableSpawnBlock{get; set;} // Eduardo --> Variavel que irá permitir a spawn do Block ou não
   public override void Enter()
>>>>>>> Stashed changes
   {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
      base.Enter();      
      //EnableSpawn = true;
=======
      base.Enter();
<<<<<<< HEAD
      EnableSpawn = true;
>>>>>>> parent of ea90abd (update Comentando os codigos)
=======
      //EnableSpawn = true;
>>>>>>> parent of 5cd038f (update Corrigindo detalhes relacionado ao mecanismo de colisao dos blocos e trap Vilao)
=======
      base.Enter();
      EnableSpawn = true;
>>>>>>> parent of ea90abd (update Comentando os codigos)
      //EnableSpawnBlock = true;
=======
      base.Enter();
>>>>>>> parent of 97a30b4 (update Criacao de spawnar trap dentro da maquina de estados com todos os detalhes corretos)
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
<<<<<<< HEAD
<<<<<<< HEAD
       // machine.ChangeTo<MoveSequenceState>();
=======
        machine.ChangeTo<MoveSequenceState>();
>>>>>>> parent of 5cd038f (update Corrigindo detalhes relacionado ao mecanismo de colisao dos blocos e trap Vilao)
        
        if(Selector.instance.spriteRenderer.sortingOrder == 300 && EnableSpawn == true) // Eduardo --> Se o selector está na ordem de renderizacao do andar 01 e se o seletor nao estiver colidindo com uma trap, é possivel inicializar o turno de spawnar trap na posicao onde o selector está, esse código esta alocado temporariamente 
        {
           machine.ChangeTo<TurnoDoVilao>();
        }

        /*if(Selector.instance.spriteRenderer.sortingOrder == 300 && EnableSpawnBlock == true) // Eduardo --> Se o selector está na ordem de renderizacao do andar 01 e se o seletor nao estiver colidindo com um bloco, é possivel inicializar o turno de spawnar bloco na posicao onde o selector está, esse código esta alocado temporariamente 
        {
           machine.ChangeTo<PathBlockedState>();
        }*/
        
=======
        machine.ChangeTo<MoveSequenceState>();
        //machine.ChangeTo<TurnoDoVilao>();
>>>>>>> parent of 97a30b4 (update Criacao de spawnar trap dentro da maquina de estados com todos os detalhes corretos)
      }
      else if(button==2)
      {
         machine.ChangeTo<ChooseActionState>();
      }
   }
}
