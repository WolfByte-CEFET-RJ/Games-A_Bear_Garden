using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] int _health;
    private int maxHealth;

    [SerializeField] private Image lifeBar;

    public delegate void PlayerDeath();
    public static event PlayerDeath PlayerDied;

    int IHealth.health => _health;

    void Start()
    {
        maxHealth = _health;
    }

    void IHealth.Damage(int damageRecieved)
    {
        _health -= damageRecieved;
        if (_health > 0)
        {
            lifeBar.fillAmount = (float)_health / maxHealth;
        } 
        else 
            OnDeath();
    }

    void IHealth.SetHealth(int value) => _health = value;

    public void OnDeath() 
    {
        gameObject.SetActive(false);
        AllPlayersDeath.allPlayerDied?.Invoke();//Delegate chamado a cada Player morto. Se apenas um ou dois morrerem, n�o acontece nada.
    }//Quando os 3 forem mortos, o metodo que ele armazena e finalmente executado.

    public int Health
    {
        get => this._health;
    }
}
