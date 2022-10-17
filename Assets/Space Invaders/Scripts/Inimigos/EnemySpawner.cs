using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private GameObject wave;

    [SerializeField] private Transform[] Effects;

    private float cronometer;
    private bool effectCreated = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cronometer += Time.deltaTime;
        if(cronometer >= timeToSpawn - 0.5f && !effectCreated)
        {
            CreateEffect();
            effectCreated = true;
        }
        if(cronometer >= timeToSpawn)
        {
            Instantiate(wave, transform.position, transform.rotation);
            cronometer = 0f;
            effectCreated = false;
        }

        if(CanvasController.EnemyWave != null)
        {
            CanvasController.EnemyWave(timeToSpawn - cronometer, timeToSpawn);
        }
        for (int i = 0; i < Effects.Length; i++)
            Effects[i].Rotate(0f, 0f, 1f, Space.World);
    }

    void CreateEffect()
    {
        for (int i = 0; i < Effects.Length; i++)
        {
            Effects[i].GetComponent<Animator>().Play("SpawnEffect");           
        }
    }
}
