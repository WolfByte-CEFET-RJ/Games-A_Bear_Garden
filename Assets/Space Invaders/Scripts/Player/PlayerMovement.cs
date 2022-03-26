using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(playerInput.GetInput() * speed * Time.deltaTime);

    }


}
