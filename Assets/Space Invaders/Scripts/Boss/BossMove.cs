using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("UI Settings")]
    [SerializeField] private Image shootCharge1;
    [SerializeField] private Image shootCharge2;

    private string shootInputName;
    private float cronometer;
    private float cronometerS;
    private float xVelocity;

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
        if(cronometer <= fireRate)
        {
            cronometer += Time.deltaTime;
            shootCharge2.fillAmount = shootCharge1.fillAmount = cronometer / fireRate;            
        }

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

        xVelocity = GetPlayerInput(playerType);
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
       rig.velocity = new Vector2(xVelocity * speed, rig.velocity.y);
    }
}
