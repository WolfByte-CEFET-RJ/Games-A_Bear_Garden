using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Aumentar vida");
        }
    }
}
