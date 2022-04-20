using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movTiro : MonoBehaviour
{

    private float speedTiro;
    public GameObject tiro;

    void Start()
    {
        speedTiro = 6;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speedTiro * Time.deltaTime);
    }

    void OnBecameInvisible(){
        Destroy(this.gameObject);
    }
}
