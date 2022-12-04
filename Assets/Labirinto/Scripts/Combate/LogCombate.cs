using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogCombate
{
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
        int ativaAlianças = 0;
        for(int i=0;i<MapLoader.instance.alianças.Count;i++)// Retorna se existe unidades vivas nas alianças
        {
            ativaAlianças+= CheckAliança(MapLoader.instance.alianças[i]);
        }
        if(ativaAlianças>1)
        {
            return false;
        }
        return true;
    }
    static int CheckAliança(Aliança aliança)// contabiliza as unidades da aliança e verifica se estao vivas
    {
        for(int i=0;i<aliança.units.Count;i++)
        {
            Unit currentUnit = aliança.units[i];
            if(currentUnit.ativa)
            {
                return 1;
            }
        }
        return 0;
    }
}
