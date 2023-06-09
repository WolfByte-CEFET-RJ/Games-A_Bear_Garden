using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : PlayerInput
{
    public Tirinho shootObject; //prefab = tirinho
    public Transform firePoint;
    private string InputName;

    [SerializeField] private float fireRate;
    private float initialFireRate;
    private float cronometer;

    [SerializeField] private Image shootCharge;

    private void Start()
    {
        initialFireRate = fireRate;
        InputName = GetShootInput(playerType);//Referenciar o nome do Input pelo metodo na classe pai
    }//Mudanca feito pelo fato de que antes, os 4 players usariam o mesmo botao pra atirar

    void Update()
    {
        //queria deixar o espaço como trigger 
        //Esse comando também acaba com o problema dos tiros estarem se multiplicando
        if(cronometer <= fireRate)
        {
            cronometer += Time.deltaTime;
            shootCharge.fillAmount = cronometer / fireRate;
        }
        if (Input.GetButton(InputName) && cronometer >= fireRate)
		{
            Shoot();
            cronometer = 0f;
		}
    }

    void Shoot()
	{
        shootObject.playerShoot = true;
        Instantiate(shootObject.gameObject, firePoint.position, firePoint.rotation);
        //gameObject.GetComponent<PlayerHealth>().AudioS.PlayOneShot(shootSound);
	}
    private int coroutineControl = 0;
    public IEnumerator SetFireRate(float effect)
    {
        PlayerMovement player = gameObject.GetComponent<PlayerMovement>();        
        fireRate = (initialFireRate / effect);
        player.OnPowerUp = true;
        player.AlteredSpeed = player.Speed = (effect * player.InitialSpeed);
        coroutineControl++;
        if (effect > 1)//Poder de velocidade
            player.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        else//Tiro especial
            player.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(5f);
        coroutineControl--;
        if (coroutineControl == 0)
        {
            player.OnPowerUp = false;
            fireRate = initialFireRate;
            player.Speed =  player.InitialSpeed;
            player.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    
}
