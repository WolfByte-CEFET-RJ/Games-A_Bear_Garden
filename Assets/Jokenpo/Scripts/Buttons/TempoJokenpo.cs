using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoJokenpo : MonoBehaviour
{
    //Script para liberar os jogadores de jogarem o Jokenpo de 6 em 6 segundos

    private int tempoInt, j;
    private float temporizador;
    public bool jogo;

    void Start()
    {
        temporizador = 0;
        j = 0;
    }
    
    void Update()
    {
        //Rodrigo --> Atualizando a variável temporizador/contabilizando a passagem de tempo
        temporizador += Time.deltaTime;

        //Rodrigo --> Atribuindo o valor de tempo a uma variável inteira
        tempoInt = (int)temporizador;

        //Rodrigo --> if para realizar o jokenpo de 6 em 6 segundos (modificar o número dividindo tempoInt para mudar o intervalo de tempo)
        if(tempoInt % 6 == 0 && tempoInt != 0)
        {
            for(int i = j; j < 1; i++)  //Rodrigo --> for que limita o for a uma vez usando o valor de j
            {
                //Debug.Log("TempoJokenpo funcionando.");
                jogo = true;
                j = 1;
            }
        }
        else    //Rodrigo --> else para resetar o valor de j
        {
            jogo = false;
            j = 0;
        }
    }
}
