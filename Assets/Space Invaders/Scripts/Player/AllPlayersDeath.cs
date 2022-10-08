using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayersDeath : MonoBehaviour
{    
    public delegate void PlayerDeath();
    public static event PlayerDeath PlayerDied;

    public GameObject player_01, player_02, player_03;


    void setup(){

    }

    void loop(){
        All_Dead();
    }

    void All_Dead()
    {
        if(player_01.activeSelf == false && player_02.activeSelf == false && player_03.activeSelf == false)
        {
            PlayerDied?.Invoke();
        }
    }
}
