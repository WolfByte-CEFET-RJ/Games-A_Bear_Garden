using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrocaDeCena : MonoBehaviour
{
    [SerializeField]
    private TempoJokenpo tmpjkp;
    public int tempoTotal, condicao;
    [SerializeField]
    private Text tempoTxt;
    [SerializeField] private vidaBase playerBase;
    [SerializeField] private vidaBase bossBase;
    
    void Start()
    {
        tempoTotal = 60;
        condicao = tmpjkp.tempoInt;
    }

    // se a variável de tempo for 0 -> troca de cena
    void Update()
    {
        tempoTxt.text = tempoTotal.ToString();

        
        if(condicao != tmpjkp.tempoInt)
        {
            tempoTotal -= 1;
            condicao += 1;
        }

        if(tempoTotal == 0)
        {
            tempoTotal = VictoryControl.instance.TimeOverVictory(playerBase.Vida, bossBase.Vida);
        }
            


    }

    void TrocaCena()
    {
            //SceneManager.LoadScene("TesteFelipe");
    }
}
