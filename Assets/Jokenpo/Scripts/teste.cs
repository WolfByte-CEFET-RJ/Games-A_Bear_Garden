using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class teste : MonoBehaviour
{

    public int vidaVilao, vidaPlayer;
    public float timer;

    public Text vidaPlayerTxt;
    public Text vidaVilaoTxt;

    private int resultP, p, v, verificacao;

   void Setup(){
       
       vidaPlayer = 3;
       vidaVilao = 3;
       timer = 0;

   }

   void Update(){
       
        timer += Time.deltaTime; // este temporizador define o tempo de resposta do vilao

        p = playerResultado();

        if(timer > 4){
            v = jokenpoVilao();
            timer = 0;

            int codigo = checkResultados(v, p);

            //RETIRA A VIDA CONFORME O RESULTADO OBTIDO NO CHECKRESULTADOS
            if(codigo == 1){
                Debug.Log("\nVilao perdeu vida!");
                vidaVilao--;
                
            }
            else if(codigo == 2){
                Debug.Log("\nPlayer perde vida!");
                vidaPlayer--;
            }
         
        }

        //EXIBE A VIDA DO PLAYER E DO VILAO
        vidaPlayerTxt.text = vidaPlayer.ToString();
        vidaVilaoTxt.text = vidaVilao.ToString();

        //SE A VIDA FOR IGUAL A 0
        if(vidaPlayer == 0){
            Debug.Log("Fim de Jogo! Vitoria do vilao.");
        }

        else if(vidaVilao == 0){
            Debug.Log("Fim de Jogo! Vitoria do Player");
        }

   }


// DECIDE SE O VILAO USARA PEDRA, PAPEL OU TESOURA
   int jokenpoVilao(){
       int a = (int) Random.Range(1, 4); // a = codigo de resposta do vilao

       switch(a){

           case 1:
            Debug.Log("\nVilao: Pedra!");
           break;

           case 2:
            Debug.Log("\nVilao: Tesoura!");
           break;

           case 3:
            Debug.Log("Vilao: Papel!");
           break;
       }

       return a;
   }

// ANALISA O RESULTADO DO VILAO E DO JOGADOR
   int checkResultados(int v, int p){    
       
       if(v == p){
           Debug.Log("\nSituacao: Empate!");
           
           verificacao = 0;             //O valor de verificacao serve para identificar em forma de codigo quem venceu o jogo
                                       // possiveis valores de verificacao e seus resultados: verificacao = 0 (empate);
                                      // verificacao = 1 (vitoria player); verificacao = 2 (vitoria vilao); 
       }

        else if( v == 3 && p == 1){
            Debug.Log("\nSituacao: Vitoria Vilao!");
            
            verificacao = 2;
        }

        else if( v == 3 && p == 2){
            Debug.Log("\nSituacao: Vitoria Player!");

            verificacao = 1;

        }

        else if(v == 2 && p == 1){
            Debug.Log("\nSituacao: Vitoria Player!");

            verificacao = 1;
        }

        else if(p == 3 && v == 2){
            Debug.Log("\nSituacao: Vitoria Vilao!");
        
            verificacao = 2;
        }

        else if(p == 3 && v == 1){
            Debug.Log("\nSituacao: Vitoria Player!");

            verificacao = 1;
        }

        else if(p == 2 && v == 1){
            Debug.Log("\nSituacao: vitoria vilao!");

            verificacao = 2;
        }

        return verificacao;
   }


// INTERPRETA A ENTRADA DO JOGADOR
   int playerResultado(){

        if(Input.GetKeyDown(KeyCode.A)){
           Debug.Log("Player: Pedra!");
           resultP = 1; //numero que representa a opcao escolhida pelo jogador
        } 

        else if(Input.GetKeyDown(KeyCode.S)){
            Debug.Log("Player: Tesoura!");
            resultP = 2; //numero que representa a opcao escolhida pelo jogador
        }

        else if(Input.GetKeyDown(KeyCode.D)){
            Debug.Log("Player: Papel!");
            resultP = 3; //numero que representa a opcao escolhida pelo jogador
        }

        return resultP;
   }
    
}
