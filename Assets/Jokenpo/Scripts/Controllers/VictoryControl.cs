using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryControl : MonoBehaviour
{
    [Header("VictoryPanels")]
    [SerializeField] private GameObject playerVicPanel;
    [SerializeField] private GameObject bossVicPanel;
    [Header("AudioConfigs")]
    [SerializeField] private AudioSource bgmPlayer;
    private AudioSource thisPlayer;
    [SerializeField] private AudioClip heroVicTheme;
    [SerializeField] private AudioClip bossVicTheme;
    private bool acabou = false;


    public static VictoryControl instance;
    private void Awake()
    {
        instance = this;
        thisPlayer = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    public void PlayerVictory()
    {
        if(!acabou)
        {
            playerVicPanel.SetActive(true);
            bgmPlayer.volume = 0;
            thisPlayer.PlayOneShot(heroVicTheme);
            StartCoroutine(ReturnPlayBGM());
            acabou = true;
        }
        
        //Time.timeScale = 0;
    }

    public void BossVictory()
    {
        if(!acabou)
        {
            bossVicPanel.SetActive(true);
            bgmPlayer.volume = 0;
            thisPlayer.PlayOneShot(bossVicTheme);
            StartCoroutine(ReturnPlayBGM());
            acabou = true;
        }
        
        //Time.timeScale = 0;
    }

    public int TimeOverVictory(float player, float boss)
    {
        if(player > boss && !acabou)
        {
            playerVicPanel.SetActive(true);
            bgmPlayer.volume = 0;
            thisPlayer.PlayOneShot(heroVicTheme);
            StartCoroutine(ReturnPlayBGM());
            acabou = true;
            return 0;
        }
        else if(boss > player && ! acabou)
        {
            bossVicPanel.SetActive(true);
            bgmPlayer.volume = 0;
            thisPlayer.PlayOneShot(bossVicTheme);
            StartCoroutine(ReturnPlayBGM());
            acabou = true;
            return 0;
        }        
        else
        {
            Debug.Log("Mais 10 segundos pra desempatar");
            return 10;
        }
    }
    private IEnumerator ReturnPlayBGM()
    {
        yield return new WaitForSeconds(bossVicTheme.length - 0.1f);
        bgmPlayer.volume = 1;
        thisPlayer.volume = 0;
        Time.timeScale = 0;
    }
}
