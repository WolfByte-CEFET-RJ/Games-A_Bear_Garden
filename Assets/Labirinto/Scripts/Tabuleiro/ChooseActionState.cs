using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseActionState : State
{
    Text txtInicioTurno;
    GameObject textoTurno;

    public override void Enter()
    {
        MoveSelector(Turnos.unit.tile);// Seletor das casa do Tabuleiro
        base.Enter();
        
        textoTurno = GameObject.Find("TurnoVilao"); //
        txtInicioTurno = textoTurno.GetComponent<Text>();   //
        
        index = 0;// posição do Seletor de Ações no tabuleiro.
        currentUISelector = machine.chooseActionSelection;
        ChangeUISelector(machine.chooseActionButtons);// Seletor da interface
        CheckAction();
        inputs.OnMove+=OnMove;
        inputs.OnFire+=OnFire;
        machine.chooseActionPainel.MoveTo("Show"); // Move o painel para a posição "Show" 0 e -50.            
    }
    public override void Exit()
    {
        base.Exit();
        inputs.OnMove-=OnMove;
        inputs.OnFire-=OnFire;
        machine.chooseActionPainel.MoveTo("Hide"); // Move o painel para a posição "Hide" 0 e 50.
    }
    void OnMove(object sender, object args)// Movimentação do Seletor ao final até o ponto inicial
    {
        Vector3Int button = (Vector3Int)args;
        if(button == Vector3Int.left)
        {
            index--;
            ChangeUISelector(machine.chooseActionButtons);// Seletor da interface
        }
        else if(button == Vector3Int.right)
        {
            index++;
            ChangeUISelector(machine.chooseActionButtons);// Seletor da interface
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

    void ActionButtons()
    {
        Debug.Log(index);
            txtInicioTurno.text = "";

            switch(index)
            {
                case 0:
                if(!Turnos.hasMoved)
                    machine.ChangeTo<MoveSelectionState>();
                    break;
                case 1:
                if(!Turnos.hasActed)
                    machine.ChangeTo<SeleçaoHabilidadeState>();
                    break;
                case 2:
                    //machine.ChangeTo<ItemSelectState>();
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

    /*void TurnoVilao(){ // Não precisa criar um turno proprio para o vilão,  pois ele ja esta na lista de unidade na contagem de turnos
        machine.ChangeTo<TurnoDoVilao>();
    }*/
}
