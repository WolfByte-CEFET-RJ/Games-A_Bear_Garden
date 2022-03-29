using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropasSpawn : MonoBehaviour
{
    //Script que regula o spawn de tropas de x em x segundos (2 atualmente)

    public GameObject tropaQualquer;
    private int tempoInt, j;
    private float temporizador;

    void Start()
    {
        temporizador = 0;
        j = 0;
    }
    
    void Update()
    {
        //Rodrigo <-- Atualizando a variável temporizador/contabilizando a passagem de tempo
        temporizador += Time.deltaTime;

        //Rodrigo <-- Atribuindo o valor de tempo a uma variável inteira
        tempoInt = (int)temporizador;

        //Rodrigo <-- if para spawnar tropas de 2 em 2 segundos (modificar o número dividindo tempoInt para mudar o intervalo de tempo)
        if(tempoInt % 2 == 0)
        {
            for(int i = j; j < 1; i++)  //Rodrigo <-- for que limita o spawn a uma vez usando o valor de j
            {
                Instantiate(tropaQualquer, transform.position, transform.rotation);
                j = 1;
            }
        }
        else    //Rodrigo <-- else para resetar o valor de j
        {
            j = 0;
        }
    }
}
