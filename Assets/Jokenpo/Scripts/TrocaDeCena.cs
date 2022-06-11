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
            TrocaCena();


    }

    void TrocaCena()
    {
            SceneManager.LoadScene("TesteFelipe");
    }
}
