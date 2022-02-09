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

        /* 
         * Tratamento individual 
         * Se o "tirinho" acertar o inimigo, acontece x
         * Se acertar o player, acontece 2x
         * 
         * para cada item acertado tem uma consequencia diferente
         */
        if (other.gameObject.tag == "Enemy")
            Destroy(gameObject);

        if (other.gameObject.tag == "Player")
            print("acertou o player");
    }

	private void OnBecameInvisible()
	{
        //quando sair da tela destroi o objeto
        Destroy(gameObject);
	}
}
