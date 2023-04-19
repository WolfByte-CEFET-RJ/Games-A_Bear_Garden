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
    [SerializeField] private AudioClip tieTheme;
    private bool acabou = false;
    [Header("TieExceptions")]
    [SerializeField]private GameObject tieTxt;
    [Header("OtherConfigs")]
    [SerializeField] private Transform timeTxt;

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
            timeTxt.position = new Vector3(0, 0, -500);//Desaparecer com o texto do tempo apos a vitoria de alguem. Poderia ter feito tirando
            acabou = true;                             // o alpha do texto, mas aí teria que importar a biblioteca da UI só pra uma mecanica
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
            timeTxt.position = new Vector3(0, 0, -500);
            acabou = true;
        }
        
        //Time.timeScale = 0;
    }

    public int TimeOverVictory(float player, float boss)
    {
        if(player > boss && !acabou)
        {
            acabou = true;
            timeTxt.position = new Vector3(0, 0, -500);
            playerVicPanel.SetActive(true);
            bgmPlayer.volume = 0;
            thisPlayer.PlayOneShot(heroVicTheme);
            StartCoroutine(ReturnPlayBGM());           
            return 0;
        }
        else if(boss > player && ! acabou)
        {
            acabou = true;
            timeTxt.position = new Vector3(0, 0, -500);
            bossVicPanel.SetActive(true);
            bgmPlayer.volume = 0;
            thisPlayer.PlayOneShot(bossVicTheme);
            StartCoroutine(ReturnPlayBGM());           
            return 0;
        }        
        else 
        {

                Debug.Log("Mais 10 segundos pra desempatar");
                StartCoroutine(Tie());
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
    private IEnumerator Tie()
    {
        if(!acabou)
        {
            tieTxt.SetActive(true);
            thisPlayer.PlayOneShot(tieTheme);
            yield return new WaitForSeconds(2f);
            tieTxt.SetActive(false);
        }     
    }
}
