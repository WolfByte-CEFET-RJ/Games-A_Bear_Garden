using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugarPainel : MonoBehaviour
{
    public List<PainelPosicao> posicoes;// lista de posicoes que serão usados para o jogo
    RectTransform rect;
    void Awake()
    {
        rect = GetComponent<RectTransform>();// Garante que não haverá nenhuma alteração no painel.
    }

    public void MoveTo(string nomeDaPosicao)

    {
        StopAllCoroutines();// Garante que não haverá nenhuma corotina em execução
        LeanTween.cancel(this.gameObject);// Garante que não haverá nenhuma animação em execução
        PainelPosicao pos = posicoes.Find(x => x.name == nomeDaPosicao);// procura a posição que tem o nome igual ao nome passado
        StartCoroutine(Move(pos));// inicia a corotina para mover o painel para a posição
    }

    IEnumerator Move(PainelPosicao painelPosicao)
    {
        rect.anchorMax = painelPosicao.anchorMax;// altera a posição do painel para a posição passada
        rect.anchorMin = painelPosicao.anchorMin; // altera a posição do painel para a posição passada

        int id = LeanTween.move(rect, painelPosicao.position, 0.5f).id;// inicia a animação de movimento do painel para a posição

        while(LeanTween.descr(id)!=null)// enquanto a animação não for concluida
        {
            yield return null;// espera um frame
        }
    }
}
