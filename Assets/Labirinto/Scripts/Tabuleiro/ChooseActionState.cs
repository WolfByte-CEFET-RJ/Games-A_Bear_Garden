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
        ChangeUISelector();
        inputs.OnMove+=OnMove;
        inputs.OnFire+=OnFire;
        machine.chooseActionPainel.MoveTo("Show"); // Move o painel para a posição "Show" 54 e -50.
    }
    public override void Exit()
    {
        base.Exit();
        inputs.OnMove-=OnMove;
        inputs.OnFire-=OnFire;
        machine.chooseActionPainel.MoveTo("Hide"); // Move o painel para a posição "Hide" 54 e 50.
    }
    void OnMove(object sender, object args)
    {
        Vector3Int button = (Vector3Int)args;
        if(button == Vector3Int.left)
        {
            index--;
            ChangeUISelector();
        }
        else if(button == Vector3Int.right)
        {
            index++;
            ChangeUISelector();
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
            machine.ChangeTo<RoamState>();
        }
    }

    void ChangeUISelector()
    {
        if(index==-1)
        {
            index = machine.chooseActionButtons.Count-1;// Seletor de Ações no tabuleiro apertado para esquerda, volta para o último item.
        }
        else if(index==machine.chooseActionButtons.Count)
        {
            index = 0;// Seletor de Ações no tabuleiro apertado para direita, volta para o primeiro item.
        }

        machine.chooseActionSelection.transform.localPosition = machine.chooseActionButtons[index].transform.localPosition;
    }

    void ActionButtons()
    {
        Debug.Log(index);
        switch(index)
        {
            case 0:
                machine.ChangeTo<MoveSelectionState>();
                break;
            case 1:
                //machine.ChangeTo<ActionSelectState>();
                break;
            case 2:
               // machine.ChangeTo<ItemSelectState>();
                break;
            case 3:
                //machine.ChangeTo<WaitState>();
                break;
        }
    }
}
