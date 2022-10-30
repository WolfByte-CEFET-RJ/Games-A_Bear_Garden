using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : PlayerInput
{
    [Header("Shoot Settings")]
    [SerializeField] private GameObject tirinho;
    [SerializeField] private GameObject specialShoot;
    [SerializeField] private Transform shootPos1;
    [SerializeField] private Transform shootPos2;
    [SerializeField] private Transform shootPosS;
    [SerializeField] private float fireRate;
    [SerializeField] private float specialFireRate;

    private string shootInputName;
    private float cronometer;
    private float cronometerS;

    [Header("Movement Settings")]
    [SerializeField] private float speed;
    private Rigidbody2D rig;

    //[Header("Sound Settings")]
    //[SerializeField] private AudioClip shootSound;
    void Start()
    {
        shootInputName = GetShootInput(playerType);
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        cronometer += Time.deltaTime;
        float shootType = Input.GetAxisRaw(shootInputName);
        if (shootType == 1 && cronometer >= fireRate)
        {
            Shoot();
            cronometer = 0f;
        }
        if(cronometerS <= specialFireRate)
            cronometerS += Time.deltaTime;

        if(shootType == -1 && cronometerS >= specialFireRate)
        {
            SpecialShoot();
            cronometerS = 0;
        }

        if (CanvasController.ShootUI != null)
        {
            CanvasController.ShootUI(specialFireRate - cronometerS, specialFireRate);
        }
    }

    void Shoot()
    {
        //gameObject.GetComponent<BossHealth>().AudioS.PlayOneShot(shootSound);
        tirinho.GetComponent<Tirinho>().playerShoot = false;
        Instantiate(tirinho, shootPos1.position, shootPos1.rotation);
        Instantiate(tirinho, shootPos2.position, shootPos2.rotation);
    }

    void SpecialShoot()
    {
        Instantiate(specialShoot, shootPosS.position, shootPosS.rotation);
    }

    private void FixedUpdate()
    {
       rig.velocity = new Vector2(GetPlayerInput(playerType) * speed, rig.velocity.y);
    }
}
