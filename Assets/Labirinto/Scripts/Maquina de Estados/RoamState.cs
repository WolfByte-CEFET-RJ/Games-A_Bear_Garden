using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : State
{
   public override void Enter()
   {
      base.Enter();
      InputController.instance.OnMove+=OnMove;
      Debug.Log("Entrou no RoamState");
      CheckNullPosition();
   }
   public override void Exit()
   {
      base.Exit();
      InputController.instance.OnMove-=OnMove;
      Debug.Log("Saiu do RoamState");
   }

   void OnMove(object sender, object args)
   {
      Vector3Int input = (Vector3Int)args;
      TileLogic t = Tabuleiro.GetTile(Selector.instance.position + input);

      if(t!=null)// Seletor do tabuleiro não saia dos limites dele
      {
         //Selector.instance.position = t.pos;
         Selector.instance.tile = t;
         Selector.instance.spriteRenderer.sortingOrder = t.contentOrder;
         Selector.instance.transform.position = t.worldPos;
      }
   }

   void CheckNullPosition()
   {
      if(Selector.instance.position==null)
      {
         TileLogic t = Tabuleiro.GetTile(new Vector3Int (-6, -6, 0)); // Posição padrão do Seletor no tabuleiro.
         //Selector.instance.position = t.pos;
         Selector.instance.tile = t;
         Selector.instance.spriteRenderer.sortingOrder = t.contentOrder;
         Selector.instance.transform.position = t.worldPos;
      }
   }
}
