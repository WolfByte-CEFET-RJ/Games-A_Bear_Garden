using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float enemyMovementSpeed = 140; // deslocamento do inimigo
	public float enemyTimer = 1; // time que o inimigo vai levar para se movimentar
	public int attemptingMoves = 6; // quantas vezes ele vai se mover antes de mudar de lado
	private float enemyMovementTimer; // variável que vai marcar o tempo
	private int timesEnemyMoved = 0; //vezes que o inimigo se moveu
	private int timesEnemyPassedThroughScreen = 0; //número de vezes que eles passaram pela tela
	private Vector3 direction; //vetor de atribuição da direção
	[SerializeField] private Transform firePos;

	private bool canSpawnP_up;
	private bool canChangeSize = true;
	private GameObject powerUp;

	[SerializeField] private AudioClip deathSound;
	private AudioSource audioS;

    private void Start()
    {
		audioS = GetComponent<AudioSource>();
    }
    public bool CanSpawnP_up
    {
		get => canSpawnP_up;
		set => canSpawnP_up = value;
    }

	public GameObject PowerUp
    {
		private get => powerUp;
		set => powerUp = value;
    }
	void Update()
	{
		//Movement();
		//Esse metodo e o primeiro estilo de movimentacao pra esse projeto. Tentei fazer um novo no metodo EnemyFatherMove, deixando esse como a
	}//Outra metade da nova logica 

	void Movement()
	{
		// atribuição do tempo
		enemyMovementTimer += Time.deltaTime;

		// numero de movimentos recebe 6 se o a variável de número de vezes que passou na tela for 0 e 12 se for em qualquer outra vez
		attemptingMoves = timesEnemyPassedThroughScreen == 0 ? 6 : 6 * 2; // pensar em uma maneira de deixar menos hard coded

		if (timesEnemyMoved == attemptingMoves) // se o número de vezes que ele se mexeu for igual ao número máximo que esperamos
		{
			timesEnemyPassedThroughScreen++; // numero de vezes que ele passou pela tela recebe +1 
			timesEnemyMoved = 0; // e o número de vezes que se moveu vira 0
		}

		// se o número de vezes que passou pela tela tiver mod 2 == 0 recebe movimento para a direita
		// senão movimento para a esquerda
		direction = timesEnemyPassedThroughScreen % 2 == 0 ? Vector3.right : Vector3.left;

		//movimento coordenado do inimigo -> de 1 em 1s o inimigo se mexe
		if (enemyMovementTimer >= enemyTimer)
		{
			// movimentação do inimigo
			transform.Translate(direction * enemyMovementSpeed * Time.deltaTime);
			timesEnemyMoved++; // toda vez que ele se move a variável aumenta 1
			enemyMovementTimer = 0; //e o timer 0
		}
	}
	public void CreateP_Up()
    {
		Instantiate(PowerUp, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Border") && canChangeSize)
        {
			Debug.Log("Encostou");
			canChangeSize = false;
			EnemyFatherMove father = GetComponentInParent<EnemyFatherMove>();
			if(father != null)
            {
				father.StartCoroutine(father.ChangeSize());
				StartCoroutine(ChangeBoolean());
            }
        }
    }
	public IEnumerator OnDeathSound()
    {
		
		audioS.PlayOneShot(deathSound);
		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<BoxCollider2D>().enabled = false;
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
    }
	public IEnumerator ChangeBoolean()
    {
		yield return new WaitForSeconds(1f);
		canChangeSize = true;//Tava dando alguns bugs dos inimigos ficarem indo multiplas vezes pra baixo, entao garanti com esse bool
    }//que ele so muda de lado apos 1 seg de uma colisao

    /* melhor usar Properties que variaveis publicas*/
    public Transform FirePosition 
	{ get { return firePos; } }

	
}

