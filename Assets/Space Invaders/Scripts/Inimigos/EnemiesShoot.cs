using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesShoot : EnemyMovement
{
    [SerializeField] List<EnemyMovement> enemies = new List<EnemyMovement>();
    [SerializeField] private float triggerTime;
    private int enemyNumber = 0;
    private int enemyCount;

    [SerializeField] private GameObject shootObject;
    [SerializeField] private GameObject powerUpObj;
    public List<EnemyMovement> Enemies
    {
        get => enemies;
        set => enemies = value;
    }

    private void Start()
    {
        enemyCount = enemies.Count;
        print($"EnemiesShoot: {enemyCount}");

        //Para aproveitar a lista, estarei selecionando aqui um inimigo para dropar um power-up quando morrer
        int enIndex = Random.Range(0, enemyCount);
        enemies[enIndex].CanSpawnP_up = true;
        enemies[enIndex].PowerUp = powerUpObj;
    }
    void Update()
	{
        if (enemyCount > 0)
        {
            triggerTime += Time.deltaTime;

            if (triggerTime >= 2)
            {
                enemyNumber = Random.Range(0, enemies.Count);
                Shoot(enemies[enemyNumber].FirePosition);
                triggerTime = 0;
            }
        }
        
    }
    void Shoot(Transform firePosition)
    {
        shootObject.GetComponent<Tirinho>().playerShoot = false;
        Instantiate(shootObject, firePosition.position, firePosition.rotation);
        
    }
    
    public void Clear()
    {
        if(enemies.Count == 0)
        {
            enemies.Clear();
        }
    }
    public int EnemyCount { get => enemyCount; set => enemyCount = value; } 

}
