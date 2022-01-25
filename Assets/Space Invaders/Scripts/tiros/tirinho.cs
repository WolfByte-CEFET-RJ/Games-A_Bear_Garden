using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirinho : MonoBehaviour
{

    public GameObject tirin;
    public GameObject player;
    public float x,y,z;
    public float speedT;


    void Start()
    {

       

    }

    
    
    void Update()
    {

        //movimenta o tiro para cima 
        transform.Translate(Vector3.up * speedT * Time.deltaTime);

        // permite que o tiro acompanhe o Player

        x = player.transform.position.x;
        y = player.transform.position.y;
        z = player.transform.position.z;

        GameObject t;

        if (Input.GetKeyDown(KeyCode.S)){

            t = Instantiate(tirin) as GameObject;
            t.transform.position = new Vector3(x,y,z);
        
        }

    }

    //destrói tiro fora da tela

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }


}
