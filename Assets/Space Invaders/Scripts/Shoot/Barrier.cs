using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour, IHealth
{
    [SerializeField] private int structure;
    private int initialStruct;
    public int health => structure;

    private SpriteRenderer sprite;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hitSound;   
    private AudioSource audioS;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        initialStruct = structure;
        audioS = GetComponent<AudioSource>();
    }
    void IHealth.Damage(int damageRecieved)
    {
        structure -= damageRecieved;
        if (structure > 0)
        {
            audioS.PlayOneShot(hitSound);
            float actualColorValue = (float)structure / initialStruct;
            sprite.color = new Color(actualColorValue, actualColorValue, actualColorValue, 1);
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            audioS.PlayOneShot(deathSound);
        }
    }

    void IHealth.SetHealth(int value) => structure = value;

    
}
