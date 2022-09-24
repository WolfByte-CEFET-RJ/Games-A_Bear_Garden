using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum PlayerType { PLAYER1, PLAYER2, PLAYER3, PLAYER4 }
    
    [SerializeField] protected PlayerType playerType;


    //Seria bom mudar isso pra que não aconteça a cada update
    protected float GetPlayerInput(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.PLAYER1:
                return  Input.GetAxis("Horizontal");//Setas pra direita e esquerda
            case PlayerType.PLAYER2:
                return  Input.GetAxis("Horizontal2");//A e D
            case PlayerType.PLAYER3:
                return  Input.GetAxis("Horizontal3");//F e H
            case PlayerType.PLAYER4:
                return  Input.GetAxis("Horizontal4");//J e L
            default: return  0;

        }
    }
    protected string GetShootInput(PlayerType type)//Metodo para retornar o nome do Input de tiro (Adicionados no Input manager)
    {
        switch (type)
        {
            case PlayerType.PLAYER1:
                return "ShootSI1";//Seta pra cima
            case PlayerType.PLAYER2:
                return "ShootSI2";//W
            case PlayerType.PLAYER3:
                return "ShootSI3";//t
            case PlayerType.PLAYER4:
                return "ShootSI4";//i
            default: Debug.LogError("Input não encontrado");
                return "null";
        }
    }
 
}
