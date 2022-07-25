
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2TropaSpawn : MonoBehaviour
{
    //Script que regula o spawn de tropas de x em x segundos (2 atualmente)

    public GameObject[] tropaQualquer; //Daniel --> Vetor para guardar prefab das tropas
    private int tempoInt, j;
    private float temporizador;

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

        //Rodrigo --> if para spawnar tropas de 2 em 2 segundos (modificar o número dividindo tempoInt para mudar o intervalo de tempo)
        if(tempoInt % 2 == 0)
        {
            for(int i = j; j < 1; i++)  //Rodrigo <-- for que limita o spawn a uma vez usando o valor de j
            {
                 if(Papel.verificacao_papel == 1) //Daniel --> If para instanciar tropa de papel caso player ganhe.
                {
                    Instantiate(tropaQualquer[1], transform.position, transform.rotation);
                    Papel.verificacao_papel = 0; //Daniel --> Atribuir zero após intanciar tropa especial para voltar a instanciar tropas normais.
                }
                else if(Tesoura.verificacao_tesoura == 1) //Daniel --> If para instanciar tropa de tesoura caso player ganhe.
                {
                    Instantiate(tropaQualquer[2], transform.position, transform.rotation);
                    Tesoura.verificacao_tesoura = 0;
                }
                else if(Pedra.verificacao_pedra == 1)  //Daniel --> If para instanciar tropa de pedra caso player ganhe.
                {
                    Instantiate(tropaQualquer[3], transform.position, transform.rotation);
                    Pedra.verificacao_pedra = 0;
                }
                else  //Daniel --> Instanciar tropas normais do player consecutivamente
                    Instantiate(tropaQualquer[0], transform.position, transform.rotation);
                j = 1;
            }
        }
        else    //Rodrigo --> else para resetar o valor de j
        {
            j = 0;
        }
    }
}
