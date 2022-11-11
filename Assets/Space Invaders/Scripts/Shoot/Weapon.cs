using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PlayerInput
{
    public Tirinho shootObject; //prefab = tirinho
    public Transform firePoint;
    private string InputName;

    [SerializeField] private float fireRate;
    private float cronometer;

    private void Start()
    {
        InputName = GetShootInput(playerType);//Referenciar o nome do Input pelo metodo na classe pai
    }//Mudanca feito pelo fato de que antes, os 4 players usariam o mesmo botao pra atirar

    void Update()
    {
        //queria deixar o espaço como trigger 
        //Esse comando também acaba com o problema dos tiros estarem se multiplicando
        cronometer += Time.deltaTime;
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

    public IEnumerator SetFireRate(float effect)
    {
        fireRate /= effect;
        gameObject.GetComponent<PlayerMovement>().OnPowerUp = true;
        gameObject.GetComponent<PlayerMovement>().Speed *= effect;
        yield return new WaitForSeconds(5f);
        gameObject.GetComponent<PlayerMovement>().OnPowerUp = false;
        fireRate *= effect;
        gameObject.GetComponent<PlayerMovement>().Speed /= effect;
    }

    
}
