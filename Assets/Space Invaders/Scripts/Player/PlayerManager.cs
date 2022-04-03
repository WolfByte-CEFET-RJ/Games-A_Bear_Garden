using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : GameManager
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerCollider playerCollider;

    private bool youWin;

    void Start()
    {
        playerCollider = GetComponentInParent<PlayerCollider>();
        PlayerHealth.PlayerDied += PlayerHealth_PlayerDied;
        base.GameStart();
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //playerCollider.GetHit();
        }
#endif
    }
    private void PlayerHealth_PlayerDied()
    {
        GameOver(!youWin);
    }

    protected override void GameOver(bool value)
    {
        print("You Lost !!!");
        base.GameOver(value);
    }

    private void OnDisable()
    {
        PlayerHealth.PlayerDied -= PlayerHealth_PlayerDied;
    }
}
