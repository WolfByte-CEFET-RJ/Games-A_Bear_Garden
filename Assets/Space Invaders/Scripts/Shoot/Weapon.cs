using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PlayerInput
{

    public Tirinho shootObject; //prefab = tirinho
    public Transform firePoint;
    private string InputName;
    private void Start()
    {
        InputName = GetShootInput(playerType);//Referenciar o nome do Input pelo metodo na classe pai
    }//Mudanca feito pelo fato de que antes, os 4 players usariam o mesmo botao pra atirar

    void Update()
    {
        //queria deixar o espa�o como trigger 
        //Esse comando tamb�m acaba com o problema dos tiros estarem se multiplicando
		if (Input.GetButtonDown(InputName))
		{
            Shoot();
		}
    }

    void Shoot()
	{
        shootObject.playerShoot = true;
        Instantiate(shootObject.gameObject, firePoint.position, firePoint.rotation);
	}
}
