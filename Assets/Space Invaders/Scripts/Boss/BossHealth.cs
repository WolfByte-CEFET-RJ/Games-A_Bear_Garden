using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour , IHealth
{
    [SerializeField] private int _health;

    int IHealth.health => _health;
    private int maxHealth;

    [SerializeField] private Image LifeBar;
    [SerializeField] private GameObject bossLosePanel;

    void Start()
    {
        SetHealth(_health);
    }
    public void Damage(int damageRecieved)
    {
        _health -= damageRecieved;
        LifeBar.fillAmount = (float)_health / maxHealth;
        if(_health <= 0)
        {
            Debug.Log("Players venceram\nBoss foi jogar no vasco");
            bossLosePanel.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void SetHealth(int value)
    {
        maxHealth = value;

    }
}
