using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour, IHealth
{
    [SerializeField] private int structure;
    public int health => structure;

    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hitSound;   
    private AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    void IHealth.Damage(int damageRecieved)
    {
        structure -= damageRecieved;
        if (structure > 0)
            audioS.PlayOneShot(hitSound);
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            audioS.PlayOneShot(deathSound);
        }
    }

    void IHealth.SetHealth(int value) => structure = value;

    
}
