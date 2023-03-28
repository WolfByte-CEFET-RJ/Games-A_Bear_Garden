using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{
    protected int index;
    protected Image currentUISelector;
    protected InputController inputs{get{return InputController.instance;}}// Redirecionador de Funçoes para o input
    protected StateMachineController machine{get{return StateMachineController.instance;}}// Redirecionador de Funçoes para o Machine
    public virtual void Enter()// Função que será chamada quando o estado for ativado
    {  
    }

    public virtual void Exit()// Função que será chamada quando o estado for terminado
    {  
    }

    protected void  OnMoveTileSelector(object sender, object args)
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
    protected void ChangeUISelector(List<Image> buttons)// Seletor da interface
    {
        if(index==-1)
        {
            index = buttons.Count-1;// Seletor de Ações no tabuleiro apertado para esquerda, volta para o último item.
        }
        else if(index==buttons.Count)
        {
            index = 0;// Seletor de Ações no tabuleiro apertado para direita, volta para o primeiro item.
        }
        currentUISelector.transform.localPosition = buttons[index].transform.localPosition;
    }
}
