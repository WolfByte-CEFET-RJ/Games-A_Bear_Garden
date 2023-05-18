using UnityEngine;
using UnityEngine.UI;

public class pronto : MonoBehaviour
{
    public Button[] buttons; // array contendo os bot�es
    public Button nextButton; // bot�o de avan�ar para a pr�xima fase
    private int buttonsActivatedCount; // contador de bot�es ativados

    void Start()
    {
        // adiciona um listener para cada bot�o
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i; // armazena o �ndice do bot�o em uma vari�vel local para evitar problemas com closures
            buttons[i].onClick.AddListener(() => { OnButtonClick(buttonIndex); });
        }

        // desativa o bot�o de avan�ar para a pr�xima fase
        nextButton.interactable = false;
    }

    void OnButtonClick(int buttonIndex)
    {
        // ativa o bot�o clicado
        buttons[buttonIndex].interactable = false;

        // atualiza o contador de bot�es ativados
        buttonsActivatedCount++;

        // verifica se todos os bot�es anteriores foram ativados
        bool allButtonsActivated = true;
        for (int i = 0; i < buttonIndex; i++)
        {
            if (buttons[i].interactable)
            {
                allButtonsActivated = false;
                break;
            }
        }

        // ativa o bot�o de avan�ar para a pr�xima fase se todos os bot�es anteriores foram ativados
        nextButton.interactable = allButtonsActivated && (buttonsActivatedCount == 4);
    }
}