using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour , IHealth
{
    [Header("Life Settings")]
    [SerializeField] private int _health;

    int IHealth.health => _health;
    private int maxHealth;
    [Header("UI Settings")]
    [SerializeField] private Image LifeBar;
    [SerializeField] private GameObject bossLosePanel;

    [Header("Sound Settings")]
    private AudioSource audioS;
    [SerializeField] private AudioClip hitSound;
    //[SerializeField] private AudioClip victorySound;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        SetHealth(_health);
    }
    public void Damage(int damageRecieved)
    {
        _health -= damageRecieved;
        LifeBar.fillAmount = (float)_health / maxHealth;
        if (_health > 0)
            audioS.PlayOneShot(hitSound);

        else
        {
            //audioS.PlayOneShot(victorySound);
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

    public AudioSource AudioS { get => audioS; private set => audioS = value; }

}
