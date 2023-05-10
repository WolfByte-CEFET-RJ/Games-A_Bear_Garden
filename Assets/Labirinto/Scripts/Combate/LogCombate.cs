using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogCombate
{
/*
    public static void VerificarEquipe(Unit unit, int equipe, Habilidade habilidade)
    {
    if(unit.equipe != equipe)
    {
        habilidade.Efeito();
    }
    else
    {
        Debug.Log("Não pode atacar jogador da mesma equipe.");
    }
    }
*/
    public static void CheckAtiva()
    {
        foreach(Unit u in StateMachineController.instance.units)
        {
            if(u.GetStat(StatEnum.HP)<=0)
            {
                u.ativa= false;//Unidade morreu
                Debug.Log("Unidade Morta");
            }
            else
            {
                u.ativa= true;//Unidade viva
                Debug.Log("Unidade Viva");
            }
        }
    }
    public static bool IsOver()
    {
        int ativaAliancas = 0;
        for(int i=0;i<MapLoader.instance.aliancas.Count;i++)// Retorna se existe unidades vivas nas alianças
        {
            ativaAliancas+= CheckAlianca(MapLoader.instance.aliancas[i]);
        }
        if(ativaAliancas>1)
        {
            return false;
        }
        return true;
    }
    static int CheckAlianca(Alianca alianca)// contabiliza as unidades da aliança e verifica se estao vivas
    {
        for(int i=0;i<alianca.units.Count;i++)
        {
            Unit currentUnit = alianca.units[i];
            if(currentUnit.ativa)
            {
                return 1;
            }
        }
        return 0;
    }
}
