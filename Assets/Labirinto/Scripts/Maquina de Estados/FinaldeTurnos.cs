using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaldeTurnos : State
{/*
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(AddUnitDelay);
        Debug.Log("Final de Turnos");

    }
    IEnumerator AddUnitDelay()
    {
        Turnos.unit.chargeTime+-300;
        if(Turnos.hasMoved)
            Turnos.unit.chargeTime+=100;
        if(Turnos.hasActed)
            Turnos.unit.chargeTime+=100;
        Turnos.unit.chargeTime-=Turnos.unit.GetStat(StatEnum.SPEED);

        Turnos.hasActed = Turnos.hasMoved = false;
        yield return null;
        machine.ChargeTo<ComeçodeTurnos>();
    }*/
}
