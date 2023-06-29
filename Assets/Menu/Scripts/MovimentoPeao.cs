using UnityEngine;

public class MovimentoPeao : MonoBehaviour
{
    public GameObject pecas;
    public Transform peao;
    public Transform[] casinhas;

    private int indiceAtual;
    private bool previousState;

    private void Start()
    {
        indiceAtual = 0;
        AtualizarPosicao();
        previousState = pecas.activeSelf;
    }

    private void LateUpdate()
    {
        bool currentState = pecas.activeSelf;

        if (currentState != previousState && currentState)
        {
            MoverParaProximaCasinha();
        }

        previousState = currentState;
    }

    public void MoverParaProximaCasinha()
    {
        indiceAtual++;
        if (indiceAtual >= casinhas.Length)
        {
            indiceAtual = 0;
        }
        print(indiceAtual);
        AtualizarPosicao();
    }

    private void AtualizarPosicao()
    {
        print(casinhas[indiceAtual].position);
        peao.position = casinhas[indiceAtual].position;
    }
}