using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropasMovimentoVilao : MonoBehaviour
{
    //Script do movimento das tropas do vilão
    public TropasScriptGeral _scriptGeral;
    float valorX;    //Rodrigo --> Valor float de velocidade da tropa
    Vector3 vetorMovimento;     //Rodrigo --> Vetor de movimento das tropas
    
    void Start()
    {
        valorX = _scriptGeral.speed;
        vetorMovimento = new Vector3(valorX, 0, 0);     //Rodrigo --> Criar o movimento das tropas (0.05: 0.05 para a direita)
    }

    void FixedUpdate()
    {
        transform.Translate(vetorMovimento, Space.World);       //Rodrigo --> Atribuir o movimento às tropas
    }
}
