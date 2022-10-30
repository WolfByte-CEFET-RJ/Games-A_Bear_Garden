using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerInput
{
    [SerializeField] private float speed;
    private float initialSpeed;

    [SerializeField] private Transform maxPosX;
    [SerializeField] private Transform minPosX;
    public float Speed { get => speed; set => speed = value; }
    private void Start()
    {
        initialSpeed = Speed;
    }
    void Update()
    {
        float move = GetPlayerInput(playerType);
        transform.Translate(new Vector2 (move * Speed * Time.deltaTime, 0));

        if ((transform.position.x <= minPosX.position.x && move < 0) || (transform.position.x >= maxPosX.position.x && move > 0)) //**   
            Speed = 0;     
        else
            Speed = initialSpeed;
    }

    //**Aqui estou fazendo uma checagem para limitar os player na tela do jogo. Se ele estiver ultrapassado o limite maximo da esquerda e ainda
    //estiver querendo ir pra esquerda (ou o exato contrario), o codigo zera a velocidade deles. caso não atenda nenhuma das condicoes (ou seja,
    //estiver no meio da tela, por exemplo), pode se mover normalmente
}
