using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trocaCorTexto1 : MonoBehaviour
{
    
    public Text textoArco;
    public Color minhaCorAmarelo = Color.yellow;
    
    

    public void trocaCor1()
    {

        textoArco.color = minhaCorAmarelo;
    }
}