using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float enemyMovementSpeed = 140;
	public float enemyTimer = 1;
	public int attemptingMoves = 6;
	private float enemyMovementTimer;
	private int timesEnemyMoved = 0;
	private int timesEnemyPassedThroughScreen = 0;
	private Vector3 direction;

	void Update()
	{
		enemyMovement();
	}

	//Tiro -> destroi inimigo
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Tiro")
			Destroy(this.gameObject);
	}

	void enemyMovement()
	{
		// atribuição do tempo
		enemyMovementTimer += Time.deltaTime;

		attemptingMoves = timesEnemyPassedThroughScreen == 0 ? 6: 6*2;

		if (timesEnemyMoved == attemptingMoves)
		{
			timesEnemyPassedThroughScreen++;
			timesEnemyMoved = 0;
		}

		direction = timesEnemyPassedThroughScreen % 2 == 0 ? Vector3.right : Vector3.left; // ainda não tá 100%

		//movimento coordenado do inimigo -> de 1 em 1s o inimigo se mexe
		if (enemyMovementTimer >= enemyTimer)
		{
			transform.Translate(direction * enemyMovementSpeed * Time.deltaTime);
			timesEnemyMoved++;
			enemyMovementTimer = 0;
			Debug.Log(timesEnemyMoved);
			Debug.Log(attemptingMoves);
		}
	}
}

