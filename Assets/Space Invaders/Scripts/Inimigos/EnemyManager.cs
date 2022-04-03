using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : GameManager
{
    EnemiesShoot enemiesShoot;
    
    private bool youLost = true;
    [SerializeField] private int enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemiesShoot = GetComponent<EnemiesShoot>();
        enemies = enemiesShoot.EnemyCount;

    }


    // Update is called once per frame
    void Update()
    {
        if (enemies <= 0)
            GameOver(youLost);
    }
    protected override void GameOver(bool value)
    {
        print("You Win!!!!");
        enemiesShoot.Clear();
        base.GameOver(value);
    }
}
