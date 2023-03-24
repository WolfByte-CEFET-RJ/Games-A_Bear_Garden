using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JogadaTecla : MonoBehaviour
{
    public TempoJokenpo tempJkp;
    private int j = 0, j1 = 0, j2 = 0;  //Rodrigo --> variáveis controladoras "j" anteriormente utilizadas seccionadas em j, j1 e j2 para diferentes análises
    public int p1, p2;
    private bool resp1 = false, resp2 = false, respostas = false;    //Rodrigo --> variáveis para checar se cada player fez sua jogada    
    public bool Resp1 { get{return this.resp1;} set { resp1 = value; } } 
    public bool Resp2 { get{return this.resp2;} set { resp2 = value; } } 
    public bool Respostas { get{return this.respostas;}set { respostas = value; } }
    public GameObject playerJogou, vilaoJogou; //Daniel --> GameObjects dos popups para mostrar quem fez a jogada na tela    

    private static bool woPlayer = false, woVilao = false;
    [Header("Sounds Config")]
    private AudioSource AS;
    [SerializeField] private AudioClip selectPlayer;
    [SerializeField] private AudioClip selectBoss;

    
    public static bool WOPLayer(){
        return woPlayer;
    }
    public static bool WOVilao(){
        return woVilao;
    }

    void Start(){
        AS = GetComponent<AudioSource>();
        Debug.Log("inicializando...");
        p1 = 0;
        p2 = 0;
    }

    void Update(){
        //Rodrigo --> chama as funções de jogada para o player 1 (Player) e 2 (Vilão) e a validação das jogadas
        Jogada_Player_01();
        Jogada_Player_02();
        checaJogada();
        RespostasFunc();
        Wo();
            
    }

    void Wo(){
         if (!resp1 && resp2 && !tempJkp.jogo)   //Rodrigo --> ifs para análise de qual jogador ganha por W.O.
        {
            for(int i = j; i < 1; i++)  //Rodrigo --> for que limita o for a uma vez usando o valor de j
            {
                woVilao = true;
                Debug.Log("Vitória do Vilão!");
                j = 1;
                resp2 = false;
            }
        }
        else if (resp1 && !resp2 && !tempJkp.jogo)
        {
            for(int i = j; i < 1; i++)
            {
                woPlayer = true;
                Debug.Log("Vitória do Player!");
                j = 1;
                resp1 = false;
            }
        }
        else
            j = 0;
    }

    void loop(){
        if(Input.GetKey(KeyCode.UpArrow)){
            Debug.Log("\n...");
        }

        //Jogada_Player_01();
        //Jogada_Player_02();
    }

    void Jogada_Player_01(){    //Rodrigo --> jogadas do player 1 (Player)
        if(tempJkp.jogo)    //Rodrigo --> caso a variável jogo seja verdadeira...
        {
            if(Input.GetKey(KeyCode.A)){    //Rodrigo --> ...joga pedra se apertado A
                for(int i = j1; i < 1; i++)   //Rodrigo --> for que limita o for a uma vez usando o valor de j1
                {
                    AS.PlayOneShot(selectPlayer);
                    TeclaResposta.PedraPlayer = true; //Daniel --> boolean pra controlar spawn de pedra do player
                    p1 = 1;
                    resp1 = true;
                    j1 = 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.S)){   //Rodrigo --> ...joga papel se apertado S
                for(int i = j1; i < 1; i++)
                {
                    AS.PlayOneShot(selectPlayer);
                    TeclaResposta.PapelPlayer = true; //Daniel --> boolean pra controlar spawn de papel do player
                    p1 = 2;
                    resp1 = true;
                    j1 = 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.D)){   //Rodrigo --> ...joga tesoura se apertado D
                for(int i = j1; i < 1; i++)
                {
                    AS.PlayOneShot(selectPlayer);
                    TeclaResposta.TesouraPlayer = true; //Daniel --> boolean pra controlar spawn de tesoura do player
                    p1 = 3;
                    resp1 = true;
                    j1 = 1;
                }
            }
        }
        else
            j1 = 0;     //Rodrigo --> reset de j1
    }

    void Jogada_Player_02(){    //Rodrigo --> jogadas do player 2 (Vilão)
        if(tempJkp.jogo)    //Rodrigo --> caso a variável jogo seja verdadeira...
        {
            if(Input.GetKeyDown(KeyCode.J)){    //Rodrigo --> ...joga pedra se apertado J
                for(int i = j2; i < 1; i++)   //Rodrigo --> for que limita o for a uma vez usando o valor de j2
                {
                    AS.PlayOneShot(selectBoss);
                    TeclaResposta.PedraVilao = true; //Daniel --> boolean pra controlar spawn de pedra do vilão
                    p2 = 1;
                    resp2 = true;
                    j2 = 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.K)){   //Rodrigo --> ...joga papel se apertado K
                for(int i = j2; i < 1; i++)
                {
                    AS.PlayOneShot(selectBoss);
                    TeclaResposta.PapelVilao = true; ; //Daniel --> boolean pra controlar spawn de papel do vilão
                    p2 = 2;
                    resp2 = true;
                    j2 = 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.L)){   //Rodrigo --> ...joga tesoura se apertado L
                for(int i = j2; i < 1; i++)
                {
                    AS.PlayOneShot(selectBoss);
                    TeclaResposta.TesouraVilao = true; //Daniel --> boolean pra controlar spawn de tesoura do vilão
                    p2 = 3;
                    resp2 = true;
                    j2 = 1;
                }
            }
        }
        else
            j2 = 0;     //Rodrigo --> reset de j2


    }

    void RespostasFunc(){
        if (resp1 && resp2) //Rodrigo --> checa se ambos os players fizeram jogadas
            respostas = true;
        else
            respostas = false;
    }

    void checaJogada() //Daniel --> Verifica quem fez a jogada para mostrar na tela
    {
        if(resp1) StartCoroutine(tempoPopuP(playerJogou));
        if(resp2) StartCoroutine(tempoPopuP(vilaoJogou));
    }

    public IEnumerator tempoPopuP(GameObject x) //Daniel --> Indicar quem ganhou na tela e 1,5 segundos depois tirar.
    {
        x.SetActive(true);
        yield return new WaitForSeconds(1.5f); //Altere esse valor para mudar os segundos.
        x.SetActive(false);
    }

    /*  minha cola, ignorem
    1 -> pedra
    2 -> papel
    3 -> tesoura
    */
}
