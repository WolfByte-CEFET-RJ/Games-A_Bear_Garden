using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropasStats : MonoBehaviour
{
    //Rodrigo --> Script para armazenar e disponibilizar stats de cada classe de tropa
    [HideInInspector]
    public float trp_vida;
    [HideInInspector]
    public float trp_atk;
    [HideInInspector]
    public float trp_spd;
    [Header("Sounds Config")]
    [SerializeField] private AudioClip[] attacks;

    //Rodrigo --> Variáveis para tropas comuns com seus valores definidos
    public void TropaComum()
    {
        trp_vida = 1;
        trp_atk = 1;
        trp_spd = 0.05f;
    }
    
    //Rodrigo --> Variáveis para supertropas com seus valores definidos    
    public void Pedra()
    {
        trp_vida = 6;
        trp_atk = 2;
        trp_spd = 0.05f;
    }

    public void Papel()
    {
        trp_vida = 4;
        trp_atk = 2;
        trp_spd = 0.075f;
    }

    public void Tesoura()
    {
        trp_vida = 4;
        trp_atk = 4;
        trp_spd = 0.05f;
    }

    public AudioClip GetSFX(int index)
    {
        return attacks[index];
    }
}
