using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Image waveTimer;

    public delegate void EnemyWaveUI(float currentTime, float maxTime);
    public static EnemyWaveUI EnemyWave;

    private void Start()
    {
        EnemyWave = SetWaveUI;
    }

    void SetWaveUI(float time, float maxTime)
    {
        waveTimer.fillAmount = time / maxTime;
    }
    public void ToScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void OnDisable()
    {
        EnemyWave -= SetWaveUI;
    }
}
