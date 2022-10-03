using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float enemyMovementSpeed = 140; // deslocamento do inimigo
	public float enemyTimer = 1; // time que o inimigo vai levar para se movimentar
	public int attemptingMoves = 6; // quantas vezes ele vai se mover antes de mudar de lado
	private float enemyMovementTimer; // vari�vel que vai marcar o tempo
	private int timesEnemyMoved = 0; //vezes que o inimigo se moveu
	private int timesEnemyPassedThroughScreen = 0; //n�mero de vezes que eles passaram pela tela
	private Vector3 direction; //vetor de atribui��o da dire��o
	[SerializeField] private Transform firePos;

	private bool canSpawnP_up;
	private GameObject powerUp;
	public bool CanSpawnP_up
    {
		get => canSpawnP_up;
		set => canSpawnP_up = value;
    }

	public GameObject PowerUp
    {
		get => powerUp;
		set => powerUp = value;
    }
	void Update()
	{
		Movement();
	}

	void Movement()
	{
		// atribui��o do tempo
		enemyMovementTimer += Time.deltaTime;

		// numero de movimentos recebe 6 se o a vari�vel de n�mero de vezes que passou na tela for 0 e 12 se for em qualquer outra vez
		attemptingMoves = timesEnemyPassedThroughScreen == 0 ? 6 : 6 * 2; // pensar em uma maneira de deixar menos hard coded

		if (timesEnemyMoved == attemptingMoves) // se o n�mero de vezes que ele se mexeu for igual ao n�mero m�ximo que esperamos
		{
			timesEnemyPassedThroughScreen++; // numero de vezes que ele passou pela tela recebe +1 
			timesEnemyMoved = 0; // e o n�mero de vezes que se moveu vira 0
		}

		// se o n�mero de vezes que passou pela tela tiver mod 2 == 0 recebe movimento para a direita
		// sen�o movimento para a esquerda
		direction = timesEnemyPassedThroughScreen % 2 == 0 ? Vector3.right : Vector3.left;

		//movimento coordenado do inimigo -> de 1 em 1s o inimigo se mexe
		if (enemyMovementTimer >= enemyTimer)
		{
			// movimenta��o do inimigo
			transform.Translate(direction * enemyMovementSpeed * Time.deltaTime);
			timesEnemyMoved++; // toda vez que ele se move a vari�vel aumenta 1
			enemyMovementTimer = 0; //e o timer 0
		}
	}

	/* melhor usar Properties que variaveis publicas*/ 
	public Transform FirePosition 
	{ get { return firePos; } }

    private void OnDestroy()
    {
        if (CanSpawnP_up)
        {
			Instantiate(powerUp, transform.position, transform.rotation);
        }
    }
}

