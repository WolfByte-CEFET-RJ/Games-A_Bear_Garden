using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropasCollision : MonoBehaviour
{
    //Script para controlar a colisão das tropas, por o esquema de vidas aqui também depois
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)      //Rodrigo <-- Detecta a colisão com uma tropa básica e destrói a tropa (esquema de vidas para  o futuro)
    {
        if(other.gameObject.tag == "TropaBasica")
        {
            //Debug.Log("colidiu!");
            Destroy(gameObject);
        }


    }
}
