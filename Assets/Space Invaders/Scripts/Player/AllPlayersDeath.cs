using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayersDeath : MonoBehaviour
{    
    public delegate void PlayerDeath();
    public static PlayerDeath allPlayerDied;
    [Header("Players References")]
    [SerializeField] private GameObject player_01;
    [SerializeField] private GameObject player_02;
    [SerializeField] private GameObject player_03;

    [Header("UI Settings")]
    [SerializeField] private GameObject playerLosePanel;

    [Header("AudioSettings")]
    [SerializeField] private AudioClip victorySound;
    [SerializeField] private AudioClip deathSound;
    private AudioSource audioS;
    [SerializeField] private AudioSource bgmAS;
    private void Start()
    {
        allPlayerDied = All_Dead;
        audioS = GetComponent<AudioSource>();
    }
    //void setup(){

    //}

    //void loop(){
    //    All_Dead();
    //}

    void All_Dead()
    {
        audioS.PlayOneShot(deathSound);
        if(player_01.activeSelf == false && player_02.activeSelf == false && player_03.activeSelf == false)
        {
            Debug.Log("Boss venceu");
            playerLosePanel.SetActive(true);
                     
            StartCoroutine(PlayVictoryTheme());
            //audioS.PlayOneShot(victorySound);            
        }
    }

    private IEnumerator PlayVictoryTheme()
    {
        GameObject player = bgmAS.gameObject;
        player.SetActive(false);
        audioS.PlayOneShot(victorySound);
        yield return new WaitForSeconds(1.8f);
        Debug.Log("Chamar musica");
        player.SetActive(true);
        allPlayerDied -= All_Dead;
        Time.timeScale = 0;
    }
}
