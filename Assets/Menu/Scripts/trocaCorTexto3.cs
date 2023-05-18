using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trocaCorTexto3 : MonoBehaviour
{
    public Text textoGuerr;
    public Color corNovaG = Color.white;
    
    

    public void trocaCor3()
    {
        textoGuerr.color = corNovaG;
    }
}

// Repita o mesmo código para TrocarCorTextoBotao2, TrocarCorTextoBotao3 e TrocarCorTextoBotao4