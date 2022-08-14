using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseActionState : State
{
    int index;

    public override void Enter()
    {
        MoveSelector(Turnos.unit.tile);
        base.Enter();
        index = 0;// posição do Seletor de Ações no tabuleiro.
        ChangeSelector();
        inputs.OnMove+=OnMove;
        inputs.OnFire+=OnFire;
        sMachine.chooseActionPainel.MoveTo("Show"); // Move o painel para a posição "Show" 54 e -50.
    }
    public override void Exit()
    {
        base.Exit();
        inputs.OnMove-=OnMove;
        inputs.OnFire-=OnFire;
        sMachine.chooseActionPainel.MoveTo("Hide"); // Move o painel para a posição "Hide" 54 e 50.
    }
    void OnMove(object sender, object args)
    {
        Vector3Int button = (Vector3Int)args;
        if(button == Vector3Int.left)
        {
            index--;
            ChangeSelector();
        }
        else if(button == Vector3Int.right)
        {
            index++;
            ChangeSelector();
        }
    }
    void OnFire(object sender, object args)
    {
        int button = (int)args;
        if(button==1)
        {
            ActionButtons();
        }
        else if(button==2)
        {
            sMachine.ChangeTo<RoamState>();
        }
    }

    void ChangeSelector()
    {
        if(index==-1)
        {
            index = sMachine.chooseActionButtons.Count-1;// Seletor de Ações no tabuleiro apertado para esquerda, volta para o último item.
        }
        else if(index==sMachine.chooseActionButtons.Count)
        {
            index = 0;// Seletor de Ações no tabuleiro apertado para direita, volta para o primeiro item.
        }

        sMachine.chooseActionSelection.transform.localPosition = sMachine.chooseActionButtons[index].transform.localPosition;
    }

    void ActionButtons()
    {
        Debug.Log(index);
        switch(index)
        {
            case 0:
                //sMachine.ChangeTo<MoveTargetState>();
                break;
            case 1:
                //sMachine.ChangeTo<ActionSelectState>();
                break;
            case 2:
               // sMachine.ChangeTo<ItemSelectState>();
                break;
            case 3:
                //sMachine.ChangeTo<WaitState>();
                break;
        }
    }
}
