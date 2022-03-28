using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tesouraTipo1 : MonoBehaviour
{
    public float vTesoura1;
    
    void Start()
    {
    
    }

    void Update()
    {
        transform.Translate(Vector3.right * vTesoura1 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other){
        
        if(other.tag == "Papel1"){

        } else if(other.tag == "Tesoura1"){

        } else if(other.tag == "Pedra1"){

        }
    }

    void OnBecameInvisible(){
        Destroy(this.gameObject);
    }
}