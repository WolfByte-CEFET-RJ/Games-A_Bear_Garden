using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerInput
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(new Vector2 (GetPlayerInput(playerType) * speed * Time.deltaTime, 0));

    }


}
