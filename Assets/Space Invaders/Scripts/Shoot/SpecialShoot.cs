using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialShoot : MonoBehaviour
{
    private Rigidbody2D rig;
    [SerializeField] private float speed;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = transform.up * speed ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Weapon play = collision.GetComponent<Weapon>();
            if(play != null)
            {
                play.StartCoroutine(play.SetFireRate(0.4f));
            }
            Destroy(gameObject);
        }

        if(collision.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}
