using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tesoura : MonoBehaviour
{
    public static int verificacao_tesoura;  //Daniel --> Variável que controla spawn de tropas de tesoura
    
    int verificacao, j = 0;
    public TempoJokenpo tempJkp;    //Rodrigo --> Variável que instancia a classe controladora do tempo "TempoJokenpo"
    public Button pedraButton;
    public Button papelButton;
    public Button tesouraButton;    //Rodrigo --> Variáveis controladoras dos botões

    void Update()   //Rodrigo --> Função para ativar e desativar o OnClick do botão
    {
        if(tempJkp.jogo)
        {
            for(int i = j; i < 1; i++)  //Rodrigo --> For para restringir a ação a uma vez (com auxílio da variável j)
            {
                tesouraButton.interactable = true;
            }
            j = 1;            
        }
        else
        {
            j = 0;
        }
    }

    // GATILHO DO SCRIPT
    public void tesoura(){
        Debug.Log("Tesoura");
        int v = jokenpoVilao();
        verificacao_tesoura = checkResultados(v);
        DesativaBotoes();
    }

    void DesativaBotoes()   //Rodrigo --> Função para desativar os botões quando ocorrer a jogada
    {
        pedraButton.interactable = false;
        papelButton.interactable = false;
        tesouraButton.interactable = false;
    }

    // DECIDE SE O VILAO USARA PEDRA, PAPEL OU TESOURA
    int jokenpoVilao(){
        int a = (int) Random.Range(1, 60); // a = codigo de resposta do vilao

       if(a <= 20){
           a = 1;
           Debug.Log("Vilao: Pedra!");
       }
       else if(a <= 40){
           a = 2;
           Debug.Log("Vilao: Tesoura!");
       }
       else{
           a = 3;
           Debug.Log("Vilao: Papel!");
       }

       return a;
   }

    //ANALISA OS RESULTADOS DO PLAYER E DO VILÃO
    int checkResultados(int v){    
       
        //Foi utilizado o sistema abaixo ao longo de todo o jogo, ou seja, esses códigos de verificação serão iguais para todos os scripts

       if(v == 3){
           Debug.Log("Situacao: Vitoria Player!");
           verificacao = 1;

       } else if(v == 2){
           Debug.Log("Situacao: Empate!");
           verificacao = 0;

       } else{
           Debug.Log("Situacao: Vitoria Vilao!");
           verificacao = 2;
       }

        return verificacao;
   }
}
