using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private GameObject wave;

    private float cronometer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cronometer += Time.deltaTime;
        if(cronometer >= timeToSpawn)
        {
            Instantiate(wave, transform.position, transform.rotation);
            cronometer = 0f;
        }
    }
}
