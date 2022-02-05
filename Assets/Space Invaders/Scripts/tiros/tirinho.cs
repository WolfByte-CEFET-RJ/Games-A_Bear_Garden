using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirinho : MonoBehaviour
{

    public float tirinhoSpeed = 20f;
    public Rigidbody2D rb;
  
    void Start()
    {
        rb.velocity = transform.up * tirinhoSpeed;
    }

    void onTriggerEnter2D()
	{
        Destroy(gameObject);
	}
}
