using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelectionState : State
{
   List<TileLogic> tiles;
    // ESTA VARIAVEL EnableSpawn E A CONDICAO DO OnFire ESTARÁ NESSE CODIGO TEMPORARIAMENTE ATÉ SER CRIADO UM ESTADO SOMENTE PARA SPAWNAR TRAP, QUE POSSA SER SELECIONADO NA HOLD BAR, SO PECO PARA NAO APAGAREM, DEIXEM COMENTADO TMJ!
    //public static bool EnableSpawn{get; set;} // Eduardo --> Variavel que irá permitir a spawn da trap ou não
    //public static bool EnableSpawnBlock{get; set;} // Eduardo --> Variavel que irá permitir a spawn do Block ou não
   public override void Enter()
   {
      base.Enter();
      inputs.OnMove+=OnMoveTileSelector;
      inputs.OnFire+=OnFire;
      tiles = Tabuleiro.instance.Search(Turnos.unit.tile);// Pesquisa os Tiles da Unidade
      tiles.Remove(Turnos.unit.tile);// Remove os mesmos Tiles da unidade
      
      //Rodrigo --> if para pintar os tiles de acordo com a aliança, utilizado para manter o tipo char na variável 'equipe'
      if(Turnos.unit.equipe == '0') //Rodrigo --> se for vilão
         Tabuleiro.instance.SelecionarTiles(tiles, 1);   //Depois pinta ele com as cores da Aliança
      else if (Turnos.unit.equipe == '1') //Rodrigo --> se for herói
         Tabuleiro.instance.SelecionarTiles(tiles, 0);   //Depois pinta ele com as cores da Aliança

   }
   public override void Exit()
   {
      base.Exit();
      inputs.OnMove-=OnMoveTileSelector;
      inputs.OnFire-=OnFire;
      Tabuleiro.instance.DeselecionarTiles(tiles);
   }
   void OnFire(object sender, object args)
   {
      int button = (int)args;
      if(button==1)
      {  
         if(tiles.Contains(machine.selectedTile))// Evita que eu selecione o Tile que os Unidade Esta(Tile abaixo do Unidade) // Referencia StateMachineController
         {
            machine.ChangeTo<MoveSequenceState>();
         }
      }
      else if(button==2)
      {
         machine.ChangeTo<ChooseActionState>();
      }
   }
}
