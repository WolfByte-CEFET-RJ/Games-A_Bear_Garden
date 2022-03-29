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
}
