using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirinho : MonoBehaviour
{

    private float tirinhoSpeed = 20f;
    [SerializeField] private Rigidbody2D rb;
    public bool playerShoot = false;
  
    void Start()
    {

        //if(playerShoot)
        //    rb.velocity = transform.up * tirinhoSpeed;
        //else
        //    rb.velocity = -transform.up * tirinhoSpeed;
        rb.velocity = transform.up * tirinhoSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //implementar uma interface com essa fun��o -> pensar nisso

        /* 
         * Tratamento individual 
         * Se o "tirinho" acertar o inimigo, acontece x
         * Se acertar o player, acontece 2x
         * 
         * para cada item acertado uma consequencia diferente
         */

        if (other.gameObject.tag == "Enemy")
        {
            //playerShoot = false;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player")
            Destroy(gameObject);
    }


	private void OnBecameInvisible()
	{
        //quando sair da tela destroi o objeto
        Destroy(gameObject);
	}
}
