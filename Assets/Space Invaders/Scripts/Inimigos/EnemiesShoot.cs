using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesShoot : MonoBehaviour
{
    public GameObject[] enemies;
    private float triggerTime;

    void Start()
    {

    }

    void Update()
	{
		triggerTime += Time.deltaTime;

		if (triggerTime >= 2)
		{
            int enemyNumber = Random.Range(0, 6);

            triggerTime = 0;
		}
        
    }
}
