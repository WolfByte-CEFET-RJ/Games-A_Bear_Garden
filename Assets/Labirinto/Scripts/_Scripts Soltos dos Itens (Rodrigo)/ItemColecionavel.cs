using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColecionavel : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D col) {
        if(col.gameObject.tag == "Unit")// se o item colecionavel colidir com uma unidade e essa unidade estiver com a velocidade 0, executará um código
        {
            Debug.Log("Velocidade Unit: "+ col.gameObject.GetComponent<Rigidbody2D>().velocity);
            
            if(Turnos.hasMoved == true)
            {
                Debug.Log("COLIDIUU");
                Destroy(this.gameObject);
                SpawnerItem.CanSpawn = true;
            }
            
        }
    }
}
