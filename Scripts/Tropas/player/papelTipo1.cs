using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papelTipo1 : MonoBehaviour
{
    public float vPapel1;
    public GameObject papel1;
    
    void Start()
    {
    
    }

    void Update()
    {
        transform.Translate(Vector3.right * vPapel1 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.tag == "Papel1"){
            Debug.Log("Colisão!");
        } else if(other.gameObject.tag == "Tesoura1"){
            Debug.Log("Colisão!");
        } else if(other.gameObject.tag == "Pedra1"){
            Debug.Log("Colisão!");
        }
    }

    void OnBecameInvisible(){
        Destroy(this.gameObject);
    }
}
