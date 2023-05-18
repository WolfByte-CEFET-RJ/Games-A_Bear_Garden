using UnityEngine;
using UnityEngine.UI;

public class pronto : MonoBehaviour
{
    public Button[] buttons; // array contendo os botões
    public Button nextButton; // botão de avançar para a próxima fase
    private int buttonsActivatedCount; // contador de botões ativados

    void Start()
    {
        // adiciona um listener para cada botão
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i; // armazena o índice do botão em uma variável local para evitar problemas com closures
            buttons[i].onClick.AddListener(() => { OnButtonClick(buttonIndex); });
        }

        // desativa o botão de avançar para a próxima fase
        nextButton.interactable = false;
    }

    void OnButtonClick(int buttonIndex)
    {
        // ativa o botão clicado
        buttons[buttonIndex].interactable = false;

        // atualiza o contador de botões ativados
        buttonsActivatedCount++;

        // verifica se todos os botões anteriores foram ativados
        bool allButtonsActivated = true;
        for (int i = 0; i < buttonIndex; i++)
        {
            if (buttons[i].interactable)
            {
                allButtonsActivated = false;
                break;
            }
        }

        // ativa o botão de avançar para a próxima fase se todos os botões anteriores foram ativados
        nextButton.interactable = allButtonsActivated && (buttonsActivatedCount == 4);
    }
}