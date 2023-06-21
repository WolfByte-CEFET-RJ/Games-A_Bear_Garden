using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeçodeTurnos : State
{
    // public bool _unidadeMorta = false;

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(SelectUnit());
        Debug.Log("Começo de Turnos");

    }
    
    IEnumerator SelectUnit()
    {
        //BreakDraw();// Garante que os Turnos das Unit não sejam os mesmos. 
        //machine.units.Sort((x, y)=>x.chargeTime.CompareTo(y.chargeTime));
        Turnos.unit = machine.units[0];// Unit está em primeiro da lista de units
        
        if(Turnos.unit.hp <= 0){    //Rodrigo --> se o player tiver 0 de vida ou menos...
            yield return null;
            machine.ChangeTo<FinaldeTurnos>();  //Rodrigo --> vai direto para o final do turno;
        }
        else{   //Rodrigo --> caso contrário...
            yield return null;
            machine.ChangeTo<ChooseActionState>();
        }

    }
    
}

