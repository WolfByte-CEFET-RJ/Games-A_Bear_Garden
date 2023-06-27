using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    int minutos, segundos;
    int tempoInt, condicao; 
    bool j; //condição para restringir as somas a uma única vez
    float temporizador;
    PlayerDeath _scriptDeath;
    [SerializeField] Text tempTxt;


    void Awake()
    {
        //aqui, todas as variáveis recebem seus valores
        _scriptDeath = GameObject.Find("EventSystem").GetComponent<PlayerDeath>();
        minutos = 5; segundos = 0;
        temporizador = 0;
        tempoInt = 0;
        j = true;
        condicao = 0;
    }

    void Update()
    {
        temporizador += Time.deltaTime; //passagem do tempo

        tempoInt = (int)temporizador;   //variável inteira do tempo
        
        if(condicao != tempoInt){   //caso passe 1 segundo...
            segundos -=1;   //...o tempo diminui...
            condicao = tempoInt;    //..e a condição é atualizada
        }
        
        if(segundos == 0 && minutos == 0){
            //não diminui o tempo
        }
        else if(segundos < 0 && j){
            segundos = 59;
            minutos -= 1;
            j = false;
        }
        else
            j = true;

        if(segundos == 0 && minutos == 0){
            _scriptDeath.victory = "Vilão";
            //SceneManager.LoadScene("FinalDoJogo");  //modificar para a cena real aqui
        }

        if(segundos >= 10)
            tempTxt.text = "0" + minutos.ToString() + ":" + segundos.ToString();
        else
            tempTxt.text = "0" + minutos.ToString() + ":0" + segundos.ToString();
    }
}
