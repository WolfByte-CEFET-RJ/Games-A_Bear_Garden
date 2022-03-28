using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedra : MonoBehaviour
{
    private int verificacao;
    public GameObject pedraPrefab, spawnPedra;

    // =================================================================================================================================//
    // GATILHO DO SCRPIT
    public void pedra(){
        
        Debug.Log("Pedra");

        GameObject spawnPedra = Instantiate(pedraPrefab) as GameObject;         // realiza o spawn da pedra
        pedraPrefab.transform.position = new Vector3(spawnPedra.transform.position.x, spawnPedra.transform.position.y, 0);                  // realiza o spawn da pedra

        int v = jokenpoVilao();                                                 // retorno da jogada do vilão
        checkResultados(v);                                                     // retorna a análise da jogada
    }
    // =================================================================================================================================//
    // DECIDE SE O VILAO USARA PEDRA, PAPEL OU TESOURA

    int jokenpoVilao(){
        int a = (int) Random.Range(1, 60);                                      // a = codigo de resposta do vilao

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

    // =================================================================================================================================//
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
