using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVictoryHero : MonoBehaviour
{
    [SerializeField] private GameObject bgmPlayer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayVictoryTheme());   
    }
    private IEnumerator PlayVictoryTheme()
    {
        Time.timeScale = 1;
        bgmPlayer.SetActive(false);
        yield return new WaitForSeconds(1.8f);
        Debug.Log("Chamar musica");
        bgmPlayer.SetActive(true);
        
        Time.timeScale = 0;
    }

}
