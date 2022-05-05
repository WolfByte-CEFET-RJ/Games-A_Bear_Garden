using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropasStats : MonoBehaviour
{
    [HideInInspector]
    public float trp_vida;
    [HideInInspector]
    public float trp_atk;
    [HideInInspector]
    public float trp_spd;

    //Variáveis para tropas comuns com seus valores definidos
    public void TropaComum()
    {
        trp_vida = 1;
        trp_atk = 1;
        //mudança de speed
        trp_spd = 0.05f;
    }
    
    //Variáveis para supertropas com seus valores definidos    
    public void Pedra()
    {
        trp_vida = 3;
        trp_atk = 1;
        //mudança de speed
        trp_spd = 0.05f;
    }

    public void Papel()
    {
        trp_vida = 2;
        trp_atk = 1;
        //mudança de speed
        trp_spd = 0.075f;
    }

    public void Tesoura()
    {
        trp_vida = 2;
        trp_atk = 2;
        //mudança de speed
        trp_spd = 0.05f;
    }
}
