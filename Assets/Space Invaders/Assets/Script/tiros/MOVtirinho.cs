using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVtirinho : MonoBehaviour
{

    public float speedT;
  
    void Start()
    {
        
    }

    

    void Update()
    {
        //movimenta o tiro para cima 
        transform.Translate(Vector3.up * speedT * Time.deltaTime);
       
    }

    //destrói tiro fora da tela

    void OnBecameInvisible() 
    {
        Destroy(this.gameObject);
    }

    
}
