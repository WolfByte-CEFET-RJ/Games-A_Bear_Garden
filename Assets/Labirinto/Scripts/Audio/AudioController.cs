using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioController : MonoBehaviour
{
    public static Action NavigateSound;
    public static Action<int> SelectSound;
    public static Action<string> EnterSound;
    public static Action<int> DeathSound;

    private AudioSource AS;
    [Header("Clips")]
    [SerializeField] private AudioClip navigateOption;
    [SerializeField] private AudioClip selectOption;
    [SerializeField] private AudioClip selectExitOption;
    [SerializeField] private AudioClip enterPlayerTurn;
    [SerializeField] private AudioClip enterBossTurn;
    [Header("Other Configs")]
    [SerializeField] private Animator deathAnim;
    // Start is called before the first frame update
    private void OnEnable()
    {
        NavigateSound += PlayNavigateSound;
        SelectSound += PlaySelectSound;
        EnterSound += PlayEnterSound;
        DeathSound += PlayDeathSound;
    }
    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }
    #region PlayXSound
    private void PlayNavigateSound()
    {
        AS.PlayOneShot(navigateOption);
    }
    private void PlaySelectSound(int audio)
    {
        if (audio == 3)//Se for a opcao passar turno
            AS.PlayOneShot(selectExitOption); //Tocar efeito sonoro diferente      
        else//Senao
            AS.PlayOneShot(selectOption);//Tocar a opcao comum de selecao
    }
    private void PlayEnterSound(String unitName)
    {
        if (unitName.StartsWith("Jogador"))
            AS.PlayOneShot(enterPlayerTurn);
        else if (unitName.StartsWith("Vilao"))
            AS.PlayOneShot(enterBossTurn);
        else
            Debug.LogError("Nome nao encontrado!");
    }
    private void PlayDeathSound(int type)
    {
        if(type == 0)
            deathAnim.Play("PlayerDeathAudio");
        else
            deathAnim.Play("BossDeathAudio");
    }
    #endregion
    private void OnDisable()
    {
        NavigateSound -= PlayNavigateSound;
        SelectSound -= PlaySelectSound;
        EnterSound -= PlayEnterSound;
        DeathSound -= PlayDeathSound;

    }
}
