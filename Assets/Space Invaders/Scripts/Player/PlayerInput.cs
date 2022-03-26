using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    protected float horizontalI;
    protected float verticalI;
    
    public Vector2 GetInput()
    {
        return new Vector2(horizontalI = Input.GetAxis("Horizontal"), verticalI = Input.GetAxis("Vertical"));
    }
}
