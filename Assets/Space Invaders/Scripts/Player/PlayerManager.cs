using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : GameManager
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerCollider playerCollider;


    void Start()
    {
        playerCollider = GetComponentInParent<PlayerCollider>();
        PlayerHealth.PlayerDied += PlayerHealth_PlayerDied; 
    }

    private void PlayerHealth_PlayerDied()
    {
        GameOver();    
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerCollider.GetHit();
        }
#endif
    }
    

    protected override void GameOver()
    {
        base.GameOver();
    }

    private void OnDisable()
    {
        PlayerHealth.PlayerDied -= PlayerHealth_PlayerDied;
    }
}
