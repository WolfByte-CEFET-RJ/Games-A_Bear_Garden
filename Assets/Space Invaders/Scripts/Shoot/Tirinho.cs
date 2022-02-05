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

    void OnTriggerEnter2D(Collider2D other)
    {
        //implementar uma interface com essa função -> pensar nisso
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
            Destroy(gameObject);
    }

	private void OnBecameInvisible()
	{
        //quando sair da tela destroi o objeto
        Destroy(gameObject);
	}
}
