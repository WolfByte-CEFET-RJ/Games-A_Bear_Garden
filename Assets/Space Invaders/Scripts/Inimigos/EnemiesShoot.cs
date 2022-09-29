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

    public List<EnemyMovement> Enemies
    {
        get => enemies;
        set => enemies = value;
    }


    void Awake()
    {
        enemyCount = enemies.Count;
        print($"EnemiesShoot: {enemyCount}");
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
