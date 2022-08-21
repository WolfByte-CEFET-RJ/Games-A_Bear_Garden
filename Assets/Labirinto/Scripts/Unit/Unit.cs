using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Unit : MonoBehaviour
{
    [HideInInspector]
    public Stats stats;
    public int equipes;// classes de vilão e jogadores
    public TileLogic tile;// Onde a unidade consegue identificar onde está.
    
    public int chargeTime;
    void Awake()
    {
        stats = GetComponentInChildren<Stats>();// informações será armazenada no stats do personagem no Objeto filho 
    }
    public int GetStat(StatEnum stat)
    {
        return stats.stats[(int)stat].value; // converte para inteiro
    }
}