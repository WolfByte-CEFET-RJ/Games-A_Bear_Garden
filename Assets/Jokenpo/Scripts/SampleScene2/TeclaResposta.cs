using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TeclaResposta : MonoBehaviour
{
    private static bool pedraPlayer, pedraVilao, papelPlayer, papelVilao, tesouraPlayer, tesouraVilao; //Daniel --> Variáveis para controle de jogadas (Encapsuladas)
    public static bool PedraPlayer { set { pedraPlayer = value; } } public static bool PapelPlayer { set { papelPlayer = value; } } //Daniel --> Setters para as variáveis de controle das jogadas
    public static bool TesouraPlayer { set { tesouraPlayer = value; } } public static bool PedraVilao { set { pedraVilao = value; } }
    public static bool PapelVilao { set { papelVilao = value; } } public static bool TesouraVilao { set { tesouraVilao = value; } }

    public GameObject[] tropas; //Daniel --> Vetor para guardar prefabs das tropas
    public GameObject spawnPlayer, spawnVilao; //Daniel --> Objetos pra instanciar os prefabs nas posições do player e vilão
    public Text resultadoText; //Daniel --> Texto do resultado da partida
    private string situacao; //Daniel --> Variável auxiliar para manipular o resultadoText

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
        if (tempoInt % 2 == 0)
        {
            for (int i = j; j < 1; i++) //Rodrigo <-- for que limita o spawn a uma vez usando o valor de j
            {
                Resposta();
                j = 1;
            }
        }
        else //Rodrigo --> else para resetar o valor de j
        {
            j = 0;
        }
    }

    void Resposta() //Daniel --> Método pra spawnar tropas de acordo com a resposta do adversário
    {
        if ((pedraPlayer == true && pedraVilao == true) || (tesouraPlayer == true && tesouraVilao == true) || (papelPlayer == true && papelVilao == true)) // Empate
        {
            Empate();
        }
        else if (papelPlayer == true && pedraVilao == true) //Vitória do Player com Papel
        {
            playerWin(0);
        }
        else if (papelVilao == true && pedraPlayer == true) //Vitória do Vilão com Papel
        {
            vilainWin(1);
        }
        else if (pedraPlayer == true && tesouraVilao == true) //Vitória do Player com Pedra
        {
            playerWin(2);
        }
        else if (pedraVilao == true && tesouraPlayer == true) //Vitória do Vilão com Pedra
        {
            vilainWin(3);
        }
        else if (tesouraPlayer == true && papelVilao == true) //Vitória do Player com Tesoura
        {
            playerWin(4);
        }
        else if (tesouraVilao == true && papelPlayer == true) //Vitória do Vilão com Tesoura
        {
            vilainWin(5);
        }
    }

    void reset() //Daniel --> Método para resetar todas as variáveis
    {
        papelPlayer = false;
        papelVilao = false;
        tesouraPlayer = false;
        tesouraVilao = false;
        pedraPlayer = false;
        pedraVilao = false;
    }

    public IEnumerator resultado(string situacao)
    {
        //Daniel --> Corrotina para mostrar a situação na tela e depois de 2 segundos limpar.
        resultadoText.text = situacao;
        yield return new WaitForSeconds(2f); //Altere esse valor para mudar os segundos.
        resultadoText.text = "";
    }

    void playerWin(int spawnIndex) //Daniel --> Spawnar tropas do player de acordo com resultado da partida caso ele ganhe
    {
        Instantiate(tropas[spawnIndex], spawnPlayer.transform.position, spawnPlayer.transform.rotation);
        reset();
        Debug.Log("Player");
        situacao = "Vitória Player!";
        StartCoroutine(resultado(situacao));
    }

    void vilainWin(int spawnIndex) //Daniel --> Spawnar tropas do vilão de acordo com resultado da partida caso ele ganhe
    {
        Instantiate(tropas[spawnIndex], spawnVilao.transform.position, spawnVilao.transform.rotation);
        reset();
        Debug.Log("Vilão");
        situacao = "Vitória Vilão!";
        StartCoroutine(resultado(situacao));
    }

    void Empate()
    {
        reset();
        Debug.Log("Empate");
        situacao = "Empate!";
        StartCoroutine(resultado(situacao));
    }
}
