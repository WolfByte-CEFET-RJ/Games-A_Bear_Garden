using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papelTipo1v : MonoBehaviour
{
    public float vPapel1;
    
    void Start()
    {
    
    }

    void Update()
    {
        transform.Translate(Vector3.right * vPapel1 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other){
        
        if(other.tag == "Papel1"){

        } else if(other.tag == "Tesoura1"){

        } else if(other.tag == "Pedra1"){

        }
    }
}
