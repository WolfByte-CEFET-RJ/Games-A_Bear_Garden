using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayersDeath : MonoBehaviour
{    
    public delegate void PlayerDeath();
    public static PlayerDeath allPlayerDied;

    public GameObject player_01, player_02, player_03;
    [SerializeField] private GameObject playerLosePanel;

    private void Start()
    {
        allPlayerDied = All_Dead;
    }
    //void setup(){

    //}

    //void loop(){
    //    All_Dead();
    //}

    void All_Dead()
    {
        if(player_01.activeSelf == false && player_02.activeSelf == false && player_03.activeSelf == false)
        {
            Debug.Log("Boss venceu");
            playerLosePanel.SetActive(true);
            Time.timeScale = 0;
            allPlayerDied -= All_Dead;
        }
    }
}
