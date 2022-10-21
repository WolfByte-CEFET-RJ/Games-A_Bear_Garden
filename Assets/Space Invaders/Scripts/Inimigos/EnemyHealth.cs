using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int _health = 50;
    
    int IHealth.health => _health;
    void IHealth.SetHealth(int value) => _health = value;

    void IHealth.Damage(int damageRecieved)
    {
        if (_health > 0)
             _health -= damageRecieved;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            IHealth health = collision.GetComponent<IHealth>();

            if(health != null)
            {
                health.Damage(20);
            }
        }
        if (collision.CompareTag("Barrier"))
        {
            Destroy(gameObject);
            IHealth health = collision.GetComponent<IHealth>();

            if (health != null)
            {
                health.Damage(10);
            }
        }

    }
}
