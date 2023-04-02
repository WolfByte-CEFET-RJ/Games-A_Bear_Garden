using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryControl : MonoBehaviour
{
    [SerializeField] private GameObject playerVicPanel;
    [SerializeField] private GameObject bossVicPanel;

    public static VictoryControl instance;
    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }

    public void PlayerVictory()
    {
        playerVicPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void BossVictory()
    {
        bossVicPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public int TimeOverVictory(float player, float boss)
    {
        if(player > boss)
        {
            playerVicPanel.SetActive(true);
            Time.timeScale = 0;
            return 0;
        }
        else if(boss > player)
        {
            bossVicPanel.SetActive(true);
            Time.timeScale = 0;
            return 0;
        }        
        else
        {
            Debug.Log("Mais 10 segundos pra desempatar");
            return 10;
        }
    }
}
