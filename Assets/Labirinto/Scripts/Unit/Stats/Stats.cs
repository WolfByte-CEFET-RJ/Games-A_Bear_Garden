using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public List<Stat> stats;// quantidade de Status do personagem e suas intereções com os objetos    void Awake()
    void Awake()
    {
        stats = new List<Stat>();
        for(int i = 0;i<10;i++)// cria 10 status de acordo com a quantidade de Emums
        {
            Stat temp = new Stat();
            temp.type = (StatEnum)i;
            stats.Add(temp);
        }
    }
}