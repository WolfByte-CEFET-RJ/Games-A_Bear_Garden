using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Papel : MonoBehaviour
{

    private int verificacao;

    //GATILHO DO SCRIPT
    public void papel(){
        Debug.Log("Papel");

        int v = jokenpoVilao();
        checkResultados(v);
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

    // ANALISA A JOGADA DO PLAYER E DO VILÃO
   int checkResultados(int v){

    /*Foi utilizado o sistema abaixo ao longo de todo o jogo, ou seja,
    esses códigos de verificação serão iguais para todos os scripts*/


       if(v == 3){
           Debug.Log("Situacao: Empate!");
           verificacao = 0;

       } else if(v == 2){
            Debug.Log("Situacao: Vitoria Vilao!");
            verificacao = 2;

       } else{
           Debug.Log("Situacao: Vitoria Player!");
           verificacao = 1;

       }

        return verificacao;
   }

}
