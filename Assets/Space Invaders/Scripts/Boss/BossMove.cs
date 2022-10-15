using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : PlayerInput
{
    [Header("Shoot Settings")]
    [SerializeField] private GameObject tirinho;
    [SerializeField] private Transform shootPos1;
    [SerializeField] private Transform shootPos2;
    [SerializeField] private float fireRate;

    private string shootInputName;
    private float cronometer;

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
        cronometer += Time.deltaTime;

        if (Input.GetButton(shootInputName) && cronometer >= fireRate)
        {
            Shoot();
            cronometer = 0f;
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
       rig.velocity = new Vector2(GetPlayerInput(playerType) * speed, rig.velocity.y);
    }
}
