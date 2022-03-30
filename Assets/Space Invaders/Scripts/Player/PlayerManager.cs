using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : GameManager
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void GameOver()
    {
        base.GameOver();
    }
}
