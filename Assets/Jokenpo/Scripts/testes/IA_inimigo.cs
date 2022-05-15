using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_inimigo : MonoBehaviour
{
    
    // randomizar a resposta do vilão (1/3, 2/3, 2/3)
    // comparar a resposta do vilão com a do player
    // retornar o resultado para o jogo

    private int verificacao_pedra, verificacao, jg = 0;
    public TempoJokenpo tempJkp;

    public void Pedra()
    {
        
        int v = jokenpoVilao();

        if(jg != 0){
            verificacao_pedra = checkResultados(v);
        } else{
            if (tempJkp.jogo){
                jg = 0;
            } else{
                jg = 1;
            }
        }

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

    // ANALISA OS RESULTADOS DO PLAYER E DO VILÃO
    int checkResultados(int v){    
       
        /*Foi utilizado o sistema abaixo ao longo de todo o jogo, ou seja,
        esses códigos de verificação serão iguais para todos os scripts*/

       if(v == 3){
           Debug.Log("Situacao: Vitoria Vilao!");
           verificacao = 2;

       } else if(v == 2){
           Debug.Log("Situacao: Vitoria Player!");
           verificacao = 1;

       } else{
           Debug.Log("Situacao: Empate!");
           verificacao = 0;

       }

        return verificacao;
   }

}
