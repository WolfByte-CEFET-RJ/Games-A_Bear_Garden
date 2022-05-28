using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedra : MonoBehaviour
{
    public static int verificacao_pedra;  //Daniel --> Variável que controla spawn de tropas de pedra
    int verificacao, j = 0;
    public TempoJokenpo tempJkp;    //Rodrigo --> Variável que instancia a classe controladora do tempo "TempoJokenpo"
    public Text resultado_pedra; //Daniel --> Variável para manipular a UI do resultado do jokenpo.
    public Button pedraButton;
    public Button papelButton;
    public Button tesouraButton;    //Rodrigo --> Variáveis controladoras dos botões

    void Update()   //Rodrigo --> Função para ativar e desativar o OnClick do botão
    {
        if(tempJkp.jogo)
        {
            for(int i = j; i < 1; i++)  //Rodrigo --> For para restringir a ação a uma vez (com auxílio da variável count)
            {
                pedraButton.interactable = true;
            }
            j = 1;            
        }
        else
        {
            j = 0;
        }
    }

    // GATILHO DO SCRPIT
    public void pedra(){
        Debug.Log("Pedra");
        int v = jokenpoVilao();
        verificacao_pedra = checkResultados(v);
        DesativaBotoes();
        //tempJkp.count = 1;  //Rodrigo --> Variável count (variável global entre os 3 botões para evitar repetições e bugs) é modificada para garantir a execução única
    }

    void DesativaBotoes()   //Rodrigo --> Função para desativar os botões quando ocorrer a jogada
    {
        pedraButton.interactable = false;
        papelButton.interactable = false;
        tesouraButton.interactable = false;
    }

    // DECIDE SE O VILAO USARA PEDRA, PAPEL OU TESOURA
    int jokenpoVilao(){
        int a = (int) Random.Range(1, 100); // a = codigo de resposta do vilao
        Debug.Log(a);

       if(a <= 100 && a > 60){ // Daniel --> 40% de chance do vilão ganhar.
           a = 3;
           Debug.Log("Vilao: Papel!");
       }
       else if(a <= 60 && a > 20){ // Daniel --> 40% de chance do player ganhar.
           a = 2;
           Debug.Log("Vilao: Tesoura!");
       }
       else{ // Daniel --> 20% de chance de dar empate.
           a = 1;
           Debug.Log("Vilao: Pedra!");
       }

       return a;
   }

    // ANALISA OS RESULTADOS DO PLAYER E DO VILÃO
    int checkResultados(int v){    
        string situacao; //Daniel --> Variável para armazenar situacao da partida a ser usada na corrotina.
       
        /*Foi utilizado o sistema abaixo ao longo de todo o jogo, ou seja,
        esses códigos de verificação serão iguais para todos os scripts*/

       if(v == 3){
           Debug.Log("Situacao: Vitoria Vilao!");
           verificacao = 2;
           situacao = "Vitoria Vilao!";
           StartCoroutine(resultado(situacao)); //Daniel --> Iniciando corrotina.

       } else if(v == 2){
           Debug.Log("Situacao: Vitoria Player!");
           verificacao = 1;
           situacao = "Vitoria Player!";
           StartCoroutine(resultado(situacao));

       } else{
           Debug.Log("Situacao: Empate!");
           verificacao = 0;
           situacao = "Empate!";
           StartCoroutine(resultado(situacao));

       }

        return verificacao;
   }

   public IEnumerator resultado(string situacao)
    {
        //Daniel --> Corrotina para mostrar a situação na tela e depois de 2 segundos limpar.
        resultado_pedra.text = situacao;
        yield return new WaitForSeconds(2f); //Altere esse valor para mudar os segundos.
        resultado_pedra.text = "";
    }

}
