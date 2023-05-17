using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Unit : MonoBehaviour
{
    [HideInInspector]
    public Stats stats;
    public char equipe;// classes de vilão e jogadores

    public TileLogic tile;// Onde a unidade consegue identificar onde está.
    public int atk, hp, mana = 0;   //Rodrigo --> Variáveis de ataque e vida do jogador
    
    public int chargeTime;
    public bool ativa; // verifica se a Unidade esta viva ou não
    
    void Awake()
    {
        stats = GetComponentInChildren<Stats>();// informações será armazenada no stats do personagem no Objeto filho       Rodrigo: -REMOVER NO FUTURO, NÃO SEI ONDE ISSO IMPLICA AINDA-
    }
    public int GetStat(StatEnum stat)
    {
        return stats.stats[(int)stat].value; // converte para inteiro
    }
    public void SetStat(StatEnum stat, int value)// faz a soma dos valores dos Stats dos jogadores
    {
        stats.stats[(int)stat].value = GetStat(stat)+value;
    }
}