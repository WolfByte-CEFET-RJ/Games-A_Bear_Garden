using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TeclaResposta : MonoBehaviour
{
    private static bool pedraPlayer, pedraVilao, papelPlayer, papelVilao, tesouraPlayer, tesouraVilao; //Daniel --> Vari�veis para controle de jogadas (Encapsuladas)
    public static bool PedraPlayer { set { pedraPlayer = value; } } public static bool PapelPlayer { set { papelPlayer = value; } } //Daniel --> Setters para as vari�veis de controle das jogadas
    public static bool TesouraPlayer { set { tesouraPlayer = value; } } public static bool PedraVilao { set { pedraVilao = value; } }
    public static bool PapelVilao { set { papelVilao = value; } } public static bool TesouraVilao { set { tesouraVilao = value; } }

    public GameObject[] tropas; //Daniel --> Vetor para guardar prefabs das tropas
    private GameObject spawnPlayer, spawnVilao; //Daniel --> Objetos pra instanciar os prefabs nas posi��es do player e vil�o
    private Text resultadoText; //Daniel --> Texto do resultado da partida
    private string situacao; //Daniel --> Vari�vel auxiliar para manipular o resultadoText

    private int tempoInt, j;
    private float temporizador;
    private JogadaTecla jogTc;

    [SerializeField] private GameObject playerMaskBox;
    [SerializeField] private GameObject bossMaskBox;

    void Start()
    {
        spawnPlayer = GameObject.FindGameObjectWithTag("spawnPlayer");
        spawnVilao = GameObject.FindGameObjectWithTag("spawnVilain");
        resultadoText =  GameObject.FindGameObjectWithTag("resultadoTxt").GetComponent<Text>();
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
        if ((pedraPlayer == true && pedraVilao == true) || (tesouraPlayer == true && tesouraVilao == true) || (papelPlayer == true && papelVilao == true)) // Empate
        {
            Empate();
        }
        else if ((papelPlayer == true && pedraVilao == true) || (papelPlayer == true && JogadaTecla.WOPLayer() == true)) //Vit�ria do Player com Papel
        {
            playerWin(0);
        }
        else if ((papelVilao == true && pedraPlayer == true) || (papelVilao == true && JogadaTecla.WOVilao() == true)) //Vit�ria do Vil�o com Papel
        {
            vilainWin(1);
        }
        else if ((pedraPlayer == true && tesouraVilao == true) || (pedraPlayer == true && JogadaTecla.WOPLayer() == true)) //Vit�ria do Player com Pedra
        {
            playerWin(2);
        }
        else if ((pedraVilao == true && tesouraPlayer == true || (pedraVilao == true && JogadaTecla.WOVilao() == true))) //Vit�ria do Vil�o com Pedra
        {
            vilainWin(3);
        }
        else if ((tesouraPlayer == true && papelVilao == true) || (tesouraPlayer == true && JogadaTecla.WOPLayer() == true)) //Vit�ria do Player com Tesoura
        {
            playerWin(4);
        }
        else if ((tesouraVilao == true && papelPlayer == true )|| (tesouraVilao == true && JogadaTecla.WOVilao() == true)) //Vit�ria do Vil�o com Tesoura
        {
            vilainWin(5);
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
        //Daniel --> Corrotina para mostrar a situacao na tela e depois de 2 segundos limpar.        
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

    void vilainWin(int spawnIndex) //Daniel --> Spawnar tropas do vil�o de acordo com resultado da partida caso ele ganhe
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
