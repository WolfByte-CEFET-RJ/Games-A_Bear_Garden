using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Papel : MonoBehaviour
{
    public static int verificacao_papel;  //Daniel --> Variável que controla spawn de tropas de papel
    int verificacao;
    public TempoJokenpo tempJkp;    //Rodrigo --> Variável que instancia a classe controladora do tempo "TempoJokenpo"
    public Text resultado_papel; //Daniel --> Variável para manipular a UI do resultado do jokenpo.
    public AtivadorBotao active;    //Rodrigo --> Variável que instancia a classe de ativação "AtivadorBotao"

    //GATILHO DO SCRIPT
    public void papel(){
        Debug.Log("Papel");
        int v = jokenpoVilao();
        verificacao_papel = checkResultados(v);
        active.DesativaBotoes();
    }

    // DECIDE SE O VILAO USARA PEDRA, PAPEL OU TESOURA
    int jokenpoVilao()
    {
        int a = (int) Random.Range(1, 100); // a = codigo de resposta do vilao
        Debug.Log(a);

       if(a <= 100 && a > 60){ // Daniel --> 40% de chance do player ganhar.
           a = 1;
           Debug.Log("Vilao: Pedra!");   
       }
       else if(a <= 60 && a > 20 ){ // Daniel --> 40% de chance do vilão ganhar.
           a = 2;
           Debug.Log("Vilao: Tesoura!");  
       }
       else{
           a = 3;
           Debug.Log("Vilao: Papel!"); // Daniel --> 20% de chance de dar empate.   
       }

       return a;
   }

    // ANALISA A JOGADA DO PLAYER E DO VILÃO
   int checkResultados(int v){
       string situacao; //Daniel --> Variável para armazenar situacao da partida a ser usada na corrotina.

        /*Foi utilizado o sistema abaixo ao longo de todo o jogo, ou seja,
        esses códigos de verificação serão iguais para todos os scripts*/


       if(v == 3){
           Debug.Log("Situacao: Empate!");
           situacao = "Empate!";
           verificacao = 0;
           StartCoroutine(resultado(situacao)); //Daniel --> Iniciando corrotina.

       } else if(v == 2){
            Debug.Log("Situacao: Vitoria Vilao!");
            situacao = "Vitoria Vilao!";
            verificacao = 2;
            StartCoroutine(resultado(situacao));

       } else{
           Debug.Log("Situacao: Vitoria Player!");
           situacao = "Vitoria Player!";
           verificacao = 1;
           StartCoroutine(resultado(situacao));

       }

        return verificacao;
   }

   public IEnumerator resultado(string situacao)
    {
        //Daniel --> Corrotina para mostrar a situação na tela e depois de 2 segundos limpar.
        resultado_papel.text = situacao;
        yield return new WaitForSeconds(2f); //Altere esse valor para mudar os segundos.
        resultado_papel.text = "";
    }

}
