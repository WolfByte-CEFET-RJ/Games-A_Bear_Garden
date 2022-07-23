using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtivadorBotao : MonoBehaviour
{

    public TempoJokenpo tempJkp;    //Rodrigo --> Variável que instancia a classe controladora do tempo "TempoJokenpo"
    public Button pedraButton;
    public Button papelButton;
    public Button tesouraButton;    //Rodrigo --> Variáveis controladoras dos botões
    int j = 0;  //Rodrigo --> Variável para restringir as ações a 1 vez no Update

    void Update()   //Rodrigo --> Função para ativar e desativar o OnClick do botão
    {
        if(tempJkp.jogo)    //Rodrigo --> If para ativar/desativar os botões de acordo com a variável de jogo "tempJkp.jogo"
        {
            for(int i = j; i < 1; i++)  //Rodrigo --> For para restringir a ação a uma vez (com auxílio da variável j)
            {
                AtivaBotoes();
            }
            j = 1;            
        }
        else
        {            
            j = 0;
            DesativaBotoes();
        }
    }

    public void DesativaBotoes()   //Rodrigo --> Função para desativar os botões quando ocorrer a jogada
    {
        pedraButton.interactable = false;
        papelButton.interactable = false;
        tesouraButton.interactable = false;
    }

    public void AtivaBotoes()   //Rodrigo --> Função para ativar os botões quando ocorrer a jogada
    {
        pedraButton.interactable = true;
        papelButton.interactable = true;
        tesouraButton.interactable = true;
    }
}
