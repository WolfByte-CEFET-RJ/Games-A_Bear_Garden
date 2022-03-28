using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedraTipo1v : MonoBehaviour
{
    public float vPedra1;
    
    void Start()
    {
    
    }

    void Update()
    {
        transform.Translate(Vector3.right * vPedra1 * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other){
        
        if(other.gameObject.CompareTag("Papel1")){
            Debug.Log("Colisão!");
        } else if(other.gameObject.CompareTag("Tesoura1")){
            Debug.Log("Colisão!");
        } else if(other.gameObject.CompareTag("Pedra1")){
            Debug.Log("Colisão!");
        }
    }
}