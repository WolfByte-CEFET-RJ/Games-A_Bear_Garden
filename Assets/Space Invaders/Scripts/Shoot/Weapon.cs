using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject shootObject; //prefab = tirinho
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        //queria deixar o espaço como trigger 
        //Esse comando também acaba com o problema dos tiros estarem se multiplicando
		if (Input.GetButtonDown("Jump"))
		{
            Shoot();
		}
    }

    void Shoot()
	{
        Instantiate(shootObject, firePoint.position, firePoint.rotation);
	}
}
