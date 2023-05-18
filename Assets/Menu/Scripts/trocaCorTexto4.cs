using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trocaCorTexto4 : MonoBehaviour
{
    public Text textoVila;
    public Color corNovaV = Color.green;
  
   

  
    public void trocaCor4()
    {
        
        textoVila.color = corNovaV;
    }
}