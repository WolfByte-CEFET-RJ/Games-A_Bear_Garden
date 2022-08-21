using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    protected InputController inputs{get{return InputController.instance;}}// 
    protected StateMachineController machine{get{return StateMachineController.instance;}}
    public virtual void Enter()// Função que será chamada quando o estado for ativado
    {
        
    }

    public virtual void Exit()// Função que será chamada quando o estado for terminado
    {
        
    }

    protected void OnMoveTileSelector(object sender, object args)
    {
        Vector3Int input = (Vector3Int)args;
        TileLogic t = Tabuleiro.GetTile(Selector.instance.position + input);
        
        if(t!=null)// Seletor do tabuleiro não saia dos limites dele
        {
            MoveSelector(t);
        }
    }

    protected void MoveSelector(Vector3Int pos)
    {
        MoveSelector(Tabuleiro.GetTile(pos));
    }
    protected void MoveSelector(TileLogic t)
    {
        Selector.instance.tile = t;
        Selector.instance.spriteRenderer.sortingOrder = t.contentOrder;
        Selector.instance.transform.position = t.worldPos;
        machine.selectedTile = t;
    }
}
