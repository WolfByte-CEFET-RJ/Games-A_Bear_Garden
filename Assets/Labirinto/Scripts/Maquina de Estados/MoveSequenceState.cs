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
        List<TileLogic> path = CreatePath();// Retorna o caminho que o player andará até a casa escolhida 
        
        
        Movimento movimento = Turnos.unit.GetComponent<Movimento>();
        yield return StartCoroutine(movimento.Move(path));
        Turnos.unit.tile = machine.selectedTile;
        yield return new WaitForSeconds(0.3f);
        Turnos.hasMoved = true;
        machine.ChangeTo<ChooseActionState>();
    }
    List<TileLogic> CreatePath()
    {
        List<TileLogic> path = new List<TileLogic>();
        TileLogic t = machine.selectedTile;
        while(t!=Turnos.unit.tile)
        {
            path.Add(t);
            t = t.prev;
        }
        path.Reverse();
        return path;

    }
}