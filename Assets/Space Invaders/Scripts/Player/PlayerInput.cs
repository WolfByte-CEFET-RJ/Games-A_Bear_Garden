using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum PlayerType { PLAYER1, PLAYER2, PLAYER3, PLAYER4 }
    
    [SerializeField] protected float horizontalI;
    [SerializeField] protected float verticalI;
    
    [SerializeField] private PlayerType tipo;

    private void Start()
    {
    }

    private void Update()
    {
        GetPlayerInput(tipo);
    }
    private void GetPlayerInput(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.PLAYER1:
                horizontalI = Input.GetAxis("Horizontal");
                break;
            case PlayerType.PLAYER2:
                horizontalI = Input.GetAxis("Horizontal2");
                break;
            case PlayerType.PLAYER3:
                horizontalI = Input.GetAxis("Horizontal3");
                break;
            case PlayerType.PLAYER4:
                horizontalI = Input.GetAxis("Horizontal4");
                break;
            default: horizontalI = verticalI = 0;
                break;

        }
    }

    public Vector2 GetInput()
    {
        return new Vector2(horizontalI, 0);
    }
}
