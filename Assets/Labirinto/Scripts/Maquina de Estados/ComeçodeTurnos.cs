using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeçodeTurnos : State
{
   public override void Enter()
    {
        base.Enter();
        StartCoroutine(SelectUnit());
        Debug.Log("Começo de Turnos");

    }
    IEnumerator SelectUnit()
    {
        BreakDraw();// Garante que os Turnos das Unit não sejam os mesmos. 
        machine.units.Sort((x, y)=>x.chargeTime.CompareTo(y.chargeTime));
        Turnos.unit = machine.units[0];// Unit está em primeiro da lista de units

        yield return null;
        machine.ChangeTo<ChooseActionState>();
    }
    void BreakDraw()
    {
        for(int i=0; i<machine.units.Count-1; i++)//irá para no penultimo da lista de units
        {
            if(machine.units[i].chargeTime== machine.units[i+1].chargeTime)
            {
                machine.units[i+1].chargeTime+=1;
            }
        } 
    }
}

