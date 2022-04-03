using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private void Pause()
    {

    }

    protected virtual void GameStart()
    {
        Time.timeScale = 1;
    }

    protected virtual void GameOver(bool condition)
    {
        print("Resultado: " + condition);
        Time.timeScale = 0;
        
        //if(condition)
        //    //youWin
        //else 
        //    //gameOverScreen.gameObject.SetActive(true);
    }
}
