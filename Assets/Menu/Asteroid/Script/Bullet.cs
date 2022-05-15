using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5f;

    void Start()
    {
        Destroy(gameObject, 1.4f);
    }

    void Update()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
