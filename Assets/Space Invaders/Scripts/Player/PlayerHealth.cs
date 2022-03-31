using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] int _health;

    public delegate void PlayerDeath();
    public static event PlayerDeath PlayerDied;

    int IHealth.health => _health;

    void IHealth.Damage(int damageRecieved)
    {
        if (_health > 0)
            _health -= damageRecieved;
        else if (_health <= 0)
            OnDeath();
    }

    void IHealth.SetHealth(int value) => _health = value;

    public void OnDeath() {
        PlayerDied?.Invoke();
        gameObject.SetActive(false);
    }

    public int Health
    {
        get => this._health;
    }
}
