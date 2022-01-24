using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVinimigo : MonoBehaviour
{
    public float speedI;
    public float timerI;

    void Start()
    {
        

    }


    void Update()
    {
        timerI += Time.deltaTime;

        //movimento coordenado do inimigo

        if (timerI > 2)
        {
            transform.Translate(Vector3.right * speedI * Time.deltaTime);
            timerI = 0;
        }
    }

    //Tiro detrói inimigo

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tiro")
            Destroy(this.gameObject);
    }
}
