using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject shootObject;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        //queria deixar o espa�o como trigger 
        //Esse comando tamb�m acaba com o problema dos tiros estarem se multiplicando
		if (Input.GetButtonDown("Jump"))
		{
            shoot();
		}
    }

    void shoot()
	{
        Instantiate(shootObject, firePoint.position, firePoint.rotation);
	}
}
