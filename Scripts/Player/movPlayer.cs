using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPlayer : MonoBehaviour
{

    public float speed, hInput;

    void Start()
    {
        speed = 10;
    }

    void Update()
    {
        
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hInput * speed * Time.deltaTime);        
    }
}
