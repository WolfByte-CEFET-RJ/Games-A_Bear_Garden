using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum PlayerType { PLAYER1, PLAYER2, PLAYER3, BOSS }
    
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
                return  Input.GetAxis("Horizontal3");//J e L
            case PlayerType.BOSS:
                return  Input.GetAxis("Horizontal4");//4 e 6 (do lado direito)
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
            case PlayerType.BOSS:
                return "ShootSI4";//8(do lado direito)
            default: Debug.LogError("Input não encontrado");
                return "null";
        }
    }
 
}
