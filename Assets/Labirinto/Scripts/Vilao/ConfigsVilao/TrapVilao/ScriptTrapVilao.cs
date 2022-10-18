using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTrapVilao : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D col) {
       Debug.Log(col.tag.ToString());
       
    }

    
}
