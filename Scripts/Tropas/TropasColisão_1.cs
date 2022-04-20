using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropasColisao : MonoBehaviour
{
    //Script em andamento, não faz nada por agora
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.relativeVelocity.magnitude > 0)
        {
            Debug.Log("colidiu!");
            //Destroy(gameObject);
        }
    }
}
