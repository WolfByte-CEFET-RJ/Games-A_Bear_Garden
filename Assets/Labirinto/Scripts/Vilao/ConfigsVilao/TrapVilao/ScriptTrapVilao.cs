using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTrapVilao : MonoBehaviour
{
    void Start(){
        
    }

    void Update(){

    }

    private void OnTriggerStay2D(Collider2D col) {
       //Debug.Log("INICIO");
        if(col.CompareTag(this.gameObject.tag))
        {
            Debug.Log("COLIDIU OS 2 INIMIGOS!");
            
            
        }
        
        
       
       
    }

    
}
