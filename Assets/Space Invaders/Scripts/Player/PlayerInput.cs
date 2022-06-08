using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInput : MonoBehaviour
{
    public enum PlayerType { PLAYER1, PLAYER2, PLAYER3, PLAYER4 }
    
    [SerializeField] protected PlayerType playerType;


    //Seria bom mudar isso pra que não aconteça a cada update
    protected float GetPlayerInput(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.PLAYER1:
                return  Input.GetAxis("Horizontal");
            case PlayerType.PLAYER2:
                return  Input.GetAxis("Horizontal2");
            case PlayerType.PLAYER3:
                return  Input.GetAxis("Horizontal3");
            case PlayerType.PLAYER4:
                return  Input.GetAxis("Horizontal4");
            default: return  0;

        }
    }

 
}
