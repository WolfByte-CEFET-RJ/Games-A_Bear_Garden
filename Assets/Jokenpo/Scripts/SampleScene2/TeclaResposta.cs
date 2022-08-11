using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TeclaResposta : MonoBehaviour
{
    public static bool pedraPlayer, pedraVilao, papelPlayer, papelVilao, tesouraPlayer, tesouraVilao;

    public GameObject[] tropas; //Daniel --> Vetor para guardar prefabs das tropas
    public GameObject spawnPlayer, spawnVilao; //Daniel --> Objetos pra instanciar os prefabs nas posi��es do player e vil�o
    public Text resultadoText;
    private string situacao;

    private int tempoInt, j;
    private float temporizador;

    void Start()
    {
        temporizador = 0;
        j = 0;
    }

    void Update()
    {
        //Rodrigo --> Atualizando a vari�vel temporizador/contabilizando a passagem de tempo
        temporizador += Time.deltaTime;

        //Rodrigo --> Atribuindo o valor de tempo a uma vari�vel inteira
        tempoInt = (int)temporizador;

        //Rodrigo --> if para spawnar tropas de 2 em 2 segundos (modificar o n�mero dividindo tempoInt para mudar o intervalo de tempo)
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

    void Resposta() //Daniel --> M�todo pra spawnar tropas de acordo com a resposta do advers�rio
    {
        if (pedraPlayer == true && pedraVilao == true) // Empate
        {
            reset();
            Debug.Log("Empate");
            situacao = "Empate!";
            StartCoroutine(resultado(situacao));
        }
        else if (tesouraPlayer == true && tesouraVilao == true) // Empate
        {
            reset();
            Debug.Log("Empate");
            situacao = "Empate!";
            StartCoroutine(resultado(situacao));
        }
        else if (papelPlayer == true && papelVilao == true) // Empate
        {
            reset();
            Debug.Log("Empate");
            situacao = "Empate!";
            StartCoroutine(resultado(situacao));
        }
        else if (papelPlayer == true && pedraVilao == true) //Vit�ria do Player com Papel
        {
            Instantiate(tropas[0], spawnPlayer.transform.position, spawnPlayer.transform.rotation); //Daniel --> Instanciar tropa de papel do player na posi��o do spawner do player
            reset();
            Debug.Log("Player");
            situacao = "Vit�ria Player!";
            StartCoroutine(resultado(situacao));
        }
        else if (papelVilao == true && pedraPlayer == true) //Vit�ria do Vil�o com Papel
        {
            Instantiate(tropas[1], spawnVilao.transform.position, spawnVilao.transform.rotation); //Daniel --> Instanciar tropa de papel do vil�o na posi��o do spawner do vil�o
            reset();
            Debug.Log("Vil�o");
            situacao = "Vit�ria Vil�o!";
            StartCoroutine(resultado(situacao));
        }
        else if (pedraPlayer == true && tesouraVilao == true) //Vit�ria do Player com Pedra
        {
            Instantiate(tropas[2], spawnPlayer.transform.position, spawnPlayer.transform.rotation);
            reset();
            Debug.Log("Player");
            situacao = "Vit�ria Player!";
            StartCoroutine(resultado(situacao));
        }
        else if (pedraVilao == true && tesouraPlayer == true) //Vit�ria do Vil�o com Pedra
        {
            Instantiate(tropas[3], spawnVilao.transform.position, spawnVilao.transform.rotation);
            reset();
            Debug.Log("Vil�o");
            situacao = "Vit�ria Vil�o!";
            StartCoroutine(resultado(situacao));
        }
        else if (tesouraPlayer == true && papelVilao == true) //Vit�ria do Player com Tesoura
        {
            Instantiate(tropas[4], spawnPlayer.transform.position, spawnPlayer.transform.rotation);
            reset();
            Debug.Log("Player");
            situacao = "Vit�ria Player!";
            StartCoroutine(resultado(situacao));
        }
        else if (tesouraVilao == true && papelPlayer == true) //Vit�ria do Vil�o com Tesoura
        {
            Instantiate(tropas[5], spawnVilao.transform.position, spawnVilao.transform.rotation);
            reset();
            Debug.Log("Vil�o");
            situacao = "Vit�ria Vil�o!";
            StartCoroutine(resultado(situacao));
        }
    }

    void reset() //Daniel --> M�todo para resetar todas as vari�veis
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
        //Daniel --> Corrotina para mostrar a situa��o na tela e depois de 2 segundos limpar.
        resultadoText.text = situacao;
        yield return new WaitForSeconds(2f); //Altere esse valor para mudar os segundos.
        resultadoText.text = "";
    }
}
