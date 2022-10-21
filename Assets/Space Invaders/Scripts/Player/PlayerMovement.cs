using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerInput
{
    [SerializeField] private float speed;

    public float Speed { get => speed; set => speed = value; }

    void Update()
    {
        transform.Translate(new Vector2 (GetPlayerInput(playerType) * Speed * Time.deltaTime, 0));

    }


}
