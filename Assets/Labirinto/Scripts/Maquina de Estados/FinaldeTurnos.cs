using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaldeTurnos : State
{
    
    PlayerDeath _scriptDeath;   //Rodrigo --> variável para receber o script PlayerDeath e utilizar o método RemoveTarget

    void Awake(){
        _scriptDeath = GameObject.Find("EventSystem").GetComponent<PlayerDeath>();  //Rodrigo --> atribuindo o script à variável
    }

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(AddUnitDelay());
        Debug.Log("Final de Turnos");

    }
    IEnumerator AddUnitDelay()// Sistema de Turnos parecido com o final fantasy
    {
        //      REMOVER ?
        /*Turnos.unit.chargeTime+=300;
        if(Turnos.hasMoved)
            Turnos.unit.chargeTime+=100;
        if(Turnos.hasActed)
            Turnos.unit.chargeTime+=100;
        Turnos.unit.chargeTime-=Turnos.unit.GetStat(StatEnum.SPEED);*/

        if(Turnos.unit.hp <= 0){    //Rodrigo --> se o player tiver 0 de vida ou menos...
                Debug.LogFormat("{0} morreu!", Turnos.unit.name);   //Rodrigo --> debuga quem morreu (mudar para um UI no futuro)
            _scriptDeath.RemoveTarget(Turnos.unit.name);    //Rodrigo --> chama a função para remover o jogador do mapa
            
            Turnos.hasActed = Turnos.hasMoved = false;
            Turnos.hasEnabledSpawnTrapVilao = false;
            machine.units.Remove(Turnos.unit);  //Rodrigo --> remove a unit da lista
            yield return new WaitForSeconds(0.5f);// Tempo entre os Turnos dos Jogadores.
            machine.ChangeTo<ComeçodeTurnos>();
        }
        else{   //Rodrigo --> caso contrário...
            Turnos.hasActed = Turnos.hasMoved = false;
            Turnos.hasEnabledSpawnTrapVilao = false;
            machine.units.Remove(Turnos.unit);// Remove a Unit da primeira colocação da Lista
            machine.units.Add(Turnos.unit);// Adiciona a Unit para a Ultima da lista de units
            yield return new WaitForSeconds(0.5f);// Tempo entre os Turnos dos Jogadores.
            machine.ChangeTo<ComeçodeTurnos>();
        }
    }
}
