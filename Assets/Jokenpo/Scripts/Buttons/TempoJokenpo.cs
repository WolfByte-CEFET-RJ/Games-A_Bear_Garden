using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoJokenpo : MonoBehaviour
{
    //Script para liberar os jogadores de jogarem o Jokenpo de 6 em 6 segundos

    [HideInInspector]
    public int condicao, tempoInt, tempoLoop, j;  //Rodrigo --> tempoInt -> valor inteiro do tempo total. Para outros scripts; tempoLoop -> valor inteiro do Loop de 1 - 6s. Para o funcionamento das rodadas
    [HideInInspector]
    public int count = 0;   //Variável gobal para limitar as jogadas a 1 click de botão
    float temporizador;
    [HideInInspector]
    public bool jogo = false;   //Rodrigo --> Variável jogo precisa ser pública para ser utiliizada em outros scritps, "[HideInInspector]" utilizado para escondê-la como se fosse privada
    public Text tempTxt, jogadaTxt;


    void Awake()
    {
        temporizador = 0;
        condicao = 0;
        j = 0;
    }
    
    //

    void Update()
    {
        //Rodrigo --> Atualizando as variáveis temporizador/contabilizando a passagem de tempo
        temporizador += Time.deltaTime;

        //Rodrigo --> Atribuindo o valor de tempo à variável inteira
        tempoLoop = (int)temporizador;

        //Felipe --> Joga o valor do temporizador para uma UI de texto na cena do jogo
        tempTxt.text = tempoLoop.ToString();
        jogadaTxt.text = condicao.ToString();

        if(condicao != tempoLoop)   //Rodrigo --> if para verificar a mudança de 1 segundo no tempo e adicionar 1 unidade à tempoInt
        {
            tempoInt += 1;
            condicao = tempoLoop;
        }

        if(tempoLoop > 6)    //Rodrigo --> If que reinicia o valor do tempo, mantendo o loop de 1 a 6 segundos;
            temporizador = 1;


        //Rodrigo --> if para realizar o jokenpo no intervalo de 5 a 6 segundos
        if(tempoLoop <= 6 && tempoLoop >= 5)
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
