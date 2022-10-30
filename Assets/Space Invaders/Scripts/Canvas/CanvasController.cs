using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Image waveTimer;
    [SerializeField] private Image shootTimer;


    public delegate void EnemyWaveUI(float currentTime, float maxTime);
    public static EnemyWaveUI EnemyWave;

    public delegate void BossShootUI(float currentTime, float maxTime);
    public static BossShootUI ShootUI;

    private void Start()
    {
        EnemyWave = SetWaveUI;
        ShootUI = SetShootUI;
    }

    void SetWaveUI(float time, float maxTime)
    {
        waveTimer.fillAmount = time / maxTime;
    }

    void SetShootUI(float time, float maxTime)
    {
        if(time <= maxTime)
        {
            shootTimer.fillAmount = time / maxTime;
        }
    }
    public void ToScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void OnDisable()
    {
        EnemyWave -= SetWaveUI;
        ShootUI -= SetShootUI;
    }
}
