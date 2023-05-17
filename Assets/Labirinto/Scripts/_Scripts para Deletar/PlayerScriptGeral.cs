using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptGeral : MonoBehaviour
{
    //Rodrigo --> Scrpit para captar os valores iniciais de cada jogador ao iniciar do jogo +
    /*
    [HideInInspector]
    public int vida;  //Rodrigo --> Variável de vida do player                          -REMOVER-
    [HideInInspector]
    public int ataque;  //Rodrigo --> Variável do ataque do player                      -REMOVER-
    [HideInInspector]
    public int mana;   //Rodrigo --> Variável de mana do player                         -REMOVER-
    //[HideInInspector]
    public char equipe; //Rodrigo --> Variável tipo char para diferenciar as equipes    -REMOVER-
    dinâmica das equipes: '0' - vilão
                            '1' - herói
    [HideInInspector] public PlayerStats _stats; //Rodrigo --> Variável para utilizar as funções e valores do script "PlayerStats"
    */
    void Awake(){
        /*_stats = GameObject.Find("BancoDeStats").GetComponent<PlayerStats>();  //Rodrigo --> utilizando o Find para encontrar o script "PlayerStats" do objeto "BancoDeStats"**/
        //empty object destinado a guardar o script de stats em um só lugar ao invés de em cada player


    }

    void Start(){
        //Rodrigo --> captando os valores iniciais
        /*removido*/
    }

    //ADICIONAR AQUI NO FUTURO: player some quando morre, limite de mana dos heróis
}
