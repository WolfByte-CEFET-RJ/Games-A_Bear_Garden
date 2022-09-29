using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : PlayerInput
{
    [Header("Shoot Settings")]
    [SerializeField] private GameObject tirinho;
    [SerializeField] private Transform shootPos1;
    [SerializeField] private Transform shootPos2;

    private string shootInputName;

    [Header("Movement Settings")]
    [SerializeField] private float speed;
    private Rigidbody2D rig;
    void Start()
    {
        shootInputName = GetShootInput(playerType);
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetButtonDown(shootInputName))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        tirinho.GetComponent<Tirinho>().playerShoot = false;
        Instantiate(tirinho, shootPos1.position, shootPos1.rotation);
        Instantiate(tirinho, shootPos2.position, shootPos2.rotation);
    }

    private void FixedUpdate()
    {
        if(GetPlayerInput(playerType) != 0)
            rig.velocity = new Vector2(GetPlayerInput(playerType) * speed, rig.velocity.y);
    }
}
