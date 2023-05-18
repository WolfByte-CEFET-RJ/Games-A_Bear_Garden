using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trocaCorTexto2 : MonoBehaviour
{
    public Text textoMago;
    public Color minhaCorRoxo = new Color(0.5f, 0f, 1f, 1f);
   

    public void trocaCor2()
    {

        textoMago.color = minhaCorRoxo;
    }
}