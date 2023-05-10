using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleçaoHabilidadeState : State
{

    //ESSA CLASSE NÃO ESTÁ SENDO MAIS UTILIZADA NA MAQUINA DE ESTADOS

    [SerializeField] Habilidade habilidadeSelected;

    public override void Enter()
    {
        base.Enter();
        index = 0;// posição do Seletor de Ações no tabuleiro.
        inputs.OnMove+=OnMove;
        inputs.OnFire+=OnFire;
        currentUISelector = machine.SeleçaoHabilidadesSelection;
        machine.SeleçaoHabilidadesPainel.MoveTo("Show"); // Move o painel para a posição "Show" 60 e 0.   
        ChangeUISelector(machine.SeleçaoHabilidadesButtons);// Seletor da interface
        CheckHabilidades();         
    }
    public override void Exit()
    {
        base.Exit();
        inputs.OnMove-=OnMove;
        inputs.OnFire-=OnFire;
        machine.SeleçaoHabilidadesPainel.MoveTo("Hide"); // Move o painel para a posição "Hide" 0 e -60.
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
            machine.ChangeTo<ChooseActionState>();
        }
    }

    void OnMove(object sender, object args)// Movimentação do Seletor ao final até o ponto inicial
    {
        Vector3Int button = (Vector3Int)args;
        if(button == Vector3Int.up)
        {
            index--;
            ChangeUISelector(machine.SeleçaoHabilidadesButtons);// Seletor da interface
        }
        else if(button == Vector3Int.down)
        {
            index++;
            ChangeUISelector(machine.SeleçaoHabilidadesButtons);// Seletor da interface
        }
    }

    void CheckHabilidades()
    {
        GameObject habilidadeObject = GameObject.FindGameObjectWithTag("Habilidade Vilao");
                   habilidadeSelected = habilidadeObject.GetComponent<Habilidade>();
    }
    void ActionButtons()
    {
       
        if(habilidadeSelected.EstaUsando())
        {
            Debug.Log("Usando "+habilidadeSelected.name);
            Turnos.habilidade = habilidadeSelected;
            machine.ChangeTo<HabilidadeTargetSate>();
        }
    }
}
