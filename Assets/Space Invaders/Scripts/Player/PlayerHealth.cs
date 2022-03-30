using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] int _health;

    int IHealth.health => _health;

    void IHealth.Damage(int damageRecieved)
    {
        if (_health > 0)
            _health -= damageRecieved;
    }

    void IHealth.SetHealth(int value) => _health = value;
     
    public int Health
    {
        get => this._health;
        set
        {
            this._health = value;
        }
    }
}
