using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    protected virtual void GameOver()
    {
        Time.timeScale = 0;
    }
}
