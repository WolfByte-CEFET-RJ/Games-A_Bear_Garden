using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropasSpawn : MonoBehaviour
{
    //Script em andamento, não faz nada por agora (nem tem nada mesmo :P)

    public GameObject tropaQualquer;
    private int tempoInt, j;
    private float temporizador;

    void Start()
    {
        //Instantiate(tropaQualquer, transform.position, transform.rotation);
        temporizador = 0;
        j = 0;
    }
    
    void Update()
    {
        //TEMPORIZADOR
        temporizador += Time.deltaTime;

        tempoInt = (int)temporizador;

        if(tempoInt % 2 == 0)
        {
            for(int i = j; j < 1; i++)
            {
                Instantiate(tropaQualquer, transform.position, transform.rotation);
                j = 1;
            }
        }
        else
        {
            j = 0;
        }
    }
}
