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

        if (other.gameObject.tag == "Enemy" && playerShoot)//Caso um tiro acerte no inimigo...
        {
            //playerShoot = false;
            Destroy(gameObject);
            //Destroy(other.gameObject);//Alem de destruir o tiro
            EnemyMovement en = other.gameObject.GetComponent<EnemyMovement>();
            if(en != null)
            {
                en.StartCoroutine(en.OnDeathSound());
                EnemiesShoot shoot = en.GetComponentInParent<EnemiesShoot>();//*
                shoot.Enemies.Remove(en);//É preciso remover ele da lista dos inimigos atuais
                shoot.EnemyCount--;//E reduzir o numero de inimigos vivos

                if(en.CanSpawnP_up)//Estava ocorrendo um bug ao chamar o Instantiate no OnDestroy ou OnDisable do inimigo, então passei a 
                {//Criacao desse power up para o momento em que ocorre o tiro
                    en.CreateP_Up();
                }
            }
        }//*Obs.: Caso seja necessário criar outros inimigos, lembrar de cria-los como filhos do objeto que possui 
        //o componente EnemiesShoot, como ja ocorre no inicio do jogo
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Boss" || other.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
            IHealth health = other.gameObject.GetComponent<IHealth>();
            if(health != null)
            {
                health.Damage(10);
            }
        }

    }


	private void OnBecameInvisible()
	{
        //quando sair da tela destroi o objeto
        Destroy(gameObject);
	}
}
