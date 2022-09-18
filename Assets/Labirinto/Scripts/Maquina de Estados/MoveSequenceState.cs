using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSequenceState : State
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(MoveSequence());
    }
    IEnumerator MoveSequence()
    {
        List<TileLogic> path = new List<TileLogic>();
        path.Add(machine.selectedTile);
        
        Movimento movimento = Turnos.unit.GetComponent<Movimento>();
        yield return StartCoroutine(movimento.Move(path));
        Turnos.unit.tile = machine.selectedTile;
        yield return new WaitForSeconds(0.5f);
        Turnos.hasMoved = true;
        machine.ChangeTo<FinaldeTurnos>();
    }

}