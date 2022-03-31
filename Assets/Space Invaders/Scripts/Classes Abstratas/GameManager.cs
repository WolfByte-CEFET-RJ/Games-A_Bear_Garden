using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameManager : MonoBehaviour
{
    
    private void Pause()
    {

    }

    protected virtual void GameStart()
    {
        Time.timeScale = 1;
    }

    protected virtual void GameOver()
    {
        Time.timeScale = 0;
        //gameOverScreen.gameObject.SetActive(true);
    }
}
