using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseActionState : State
{
    int index;

    public override void Enter()
    {
        MoveSelector(Turnos.unit.tile);
        base.Enter();
        index = 0;// posição do Seletor de Ações no tabuleiro.
        ChangeUISelector();// Seletor da interface
        CheckAction();
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
            ChangeUISelector();// Seletor da interface
        }
        else if(button == Vector3Int.right)
        {
            index++;
            ChangeUISelector();// Seletor da interface
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

    void ChangeUISelector()// Seletor da interface
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
            if(!Turnos.hasMoved)
            {
                machine.ChangeTo<MoveSelectionState>();
            }
                break;
            case 1:
                //machine.ChangeTo<ActionSelectState>();
                break;
            case 2:
               // machine.ChangeTo<ItemSelectState>();
                break;
            case 3:
                machine.ChangeTo<FinaldeTurnos>();
                break;
        }
    }
    void CheckAction()
    {
        PaintButton(machine.chooseActionButtons[0], Turnos.hasMoved);
        PaintButton(machine.chooseActionButtons[1], Turnos.hasActed);// Cor Skills
        PaintButton(machine.chooseActionButtons[2], Turnos.hasActed);// Cor Item 
    }
    void PaintButton(Image image, bool check)// Seletor da interface irá trocar de Cor se Ele se Mover para Cinza, Senão continuará Branco
    {
        if(check)
        {
            image.color = Color.gray;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
