using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoJokenpo : MonoBehaviour
{
    //Script para liberar os jogadores de jogarem o Jokenpo de 6 em 6 segundos

    int tempoInt, j;
    [HideInInspector]
    public int count = 0;   //variável gobal para limitar as jogadas a 1 click de botão
    float temporizador;
    [HideInInspector]
    public bool jogo = false;   //Rodrigo --> Variável jogo precisa ser pública para ser utiliizada em outros scritps, "[HideInInspector]" utilizado para escondê-la como se fosse privada
    public Text tempTxt;


    void Awake()
    {
        temporizador = 0;
        j = 0;
    }
    
    //

    void Update()
    {
        //Rodrigo --> Atualizando as variáveis temporizador/contabilizando a passagem de tempo
        temporizador += Time.deltaTime;

        //Rodrigo --> Atribuindo os valores de tempo a variáveis inteiras
        tempoInt = (int)temporizador;

        //Felipe --> Joga o valor do temporizador para uma UI de texto na cena do jogo
        tempTxt.text = tempoInt.ToString();

        if(tempoInt > 6)    //Rodrigo --> If que reinicia o valor do tempo, mantendo o loop de 0 a 6 segundos;
            temporizador = 1;

        //Rodrigo --> if para realizar o jokenpo no intervalo de 5 a 6 segundos
        if(tempoInt <= 6 && tempoInt >= 5)
        {

            for(int i = j; j < 1; i++)  //Rodrigo --> for que limita o for a uma vez usando o valor de j
            {
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
