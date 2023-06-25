using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour, IHealth
{
    [SerializeField] private int structure;
    private int initialStruct;
    public int health => structure;

    private SpriteRenderer sprt;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hitSound;

    [SerializeField] private Sprite halfLifeSprite;
    [SerializeField] private Sprite lessLifeSprite;
    private AudioSource audioS;

    void Start()
    {
        sprt = GetComponent<SpriteRenderer>();
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
            sprt.color = new Color(actualColorValue, actualColorValue, actualColorValue, 1);
            if (actualColorValue <= 0.333f)
                sprt.sprite = lessLifeSprite;
            else if (actualColorValue <= 0.6777f)
                sprt.sprite = halfLifeSprite;
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
