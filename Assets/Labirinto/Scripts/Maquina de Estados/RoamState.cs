using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : State
{
   public override void Enter()
   {
      base.Enter();
      inputs.OnMove+=OnMoveTileSelector;
      inputs.OnFire+=OnFire;
      Debug.Log("Entrou no RoamState");
      CheckNullPosition();
   }
   public override void Exit()
   {
      base.Exit();
      inputs.OnMove-=OnMoveTileSelector;
      inputs.OnFire-=OnFire;
      Debug.Log("Saiu do RoamState");
   }


   void OnFire(object sender, object args)
   {
      int button = (int)args;
      if(button==1)
      {
         
      }
      else if(button==2)
      {
         machine.ChangeTo<ChooseActionState>();
      }
   }
   void CheckNullPosition()// faz a checagem do seletor no tabuleiro
   {
      if(Selector.instance.tile==null)
      {
         TileLogic t = Tabuleiro.GetTile(new Vector3Int (-6, -6, 0)); // Posição padrão do Seletor no tabuleiro.
         //Selector.instance.position = t.pos;
         Selector.instance.tile = t;
         Selector.instance.spriteRenderer.sortingOrder = t.contentOrder;
         Selector.instance.transform.position = t.worldPos;
      }
   }
}
