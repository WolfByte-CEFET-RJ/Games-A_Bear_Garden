using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadaTecla : MonoBehaviour
{
    public TempoJokenpo tempJkp;
    private int j = 0, j1 = 0, j2 = 0;  //Rodrigo --> variáveis controladoras "j" anteriormente utilizadas seccionadas em j, j1 e j2 para diferentes análises
    public int p1, p2;
    public bool resp1 = false, resp2 = false, respostas = false;    //Rodrigo --> variáveis para checar se cada player fez sua jogada

    void Start(){
        Debug.Log("inicializando...");
        p1 = 0;
        p2 = 0;
    }

    void Update(){
        //Rodrigo --> chama as funções de jogada para o player 1 (Player) e 2 (Vilão) e a validação das jogadas
        Jogada_Player_01();
        Jogada_Player_02();
        Respostas();
        
        if (!resp1 && resp2 && !tempJkp.jogo)   //Rodrigo --> ifs para análise de qual jogador ganha por W.O.
        {
            for(int i = j; i < 1; i++)  //Rodrigo --> for que limita o for a uma vez usando o valor de j
            {
                Debug.Log("Vitória do Vilão!");
                j = 1;
                resp2 = false;
            }
        }
        else if (resp1 && !resp2 && !tempJkp.jogo)
        {
            for(int i = j; i < 1; i++)
            {
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
                    p1 = 1;
                    resp1 = true;
                    j1 = 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.S)){   //Rodrigo --> ...joga papel se apertado S
                for(int i = j1; i < 1; i++)
                {
                    p1 = 2;
                    resp1 = true;
                    j1 = 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.D)){   //Rodrigo --> ...joga tesoura se apertado D
                for(int i = j1; i < 1; i++)
                {
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
                    p2 = 1;
                    resp2 = true;
                    j2 = 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.K)){   //Rodrigo --> ...joga papel se apertado K
                for(int i = j2; i < 1; i++)
                {
                    p2 = 2;
                    resp2 = true;
                    j2 = 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.L)){   //Rodrigo --> ...joga tesoura se apertado L
                for(int i = j2; i < 1; i++)
                {
                    p2 = 3;
                    resp2 = true;
                    j2 = 1;
                }
            }
        }
        else
            j2 = 0;     //Rodrigo --> reset de j2


    }

    void Respostas(){
        if(resp1 && resp2)  //Rodrigo --> checa se ambos os players fizeram jogadas
            respostas = true;
        else
            respostas = false;

    }

    /*  minha cola, ignorem
    1 -> pedra
    2 -> papel
    3 -> tesoura
    */
}
