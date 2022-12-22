using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialShoot : MonoBehaviour
{
    private Rigidbody2D rig;
    [SerializeField] private float speed;

    private AudioSource AS;
    [SerializeField] private AudioClip nerfHitSound;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        AS = GetComponent<AudioSource>();
        rig.velocity = transform.up * speed ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Weapon play = collision.GetComponent<Weapon>();
            if(play != null)
            {
                AS.PlayOneShot(nerfHitSound);
                play.StartCoroutine(play.SetFireRate(0.4f));
            }
            //Destroy(gameObject);
        }

        if(collision.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, nerfHitSound.length);
    }
}
