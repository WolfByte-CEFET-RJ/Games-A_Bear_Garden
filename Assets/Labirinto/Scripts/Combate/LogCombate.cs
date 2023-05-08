using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogCombate
{
    /*
    int P = h (1, 2, 3, 4)  //descobrir qual player na maq estado
    if (P == 1){
        PlayerScriptGeral var = GameObject.Find("Jogador 1").GetComponent<PlayerScriptGeral>();
    }
    else if (P == 4)
        "vilão"

    if (atacando.equipe != var.equipe){
        script de ataque
    }
    else{
        mensagem de erro
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
