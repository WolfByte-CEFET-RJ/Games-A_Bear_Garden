using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioController : MonoBehaviour
{
    public static Action NavigateSound;//Actions sao tipos de delegates especiais, que tem a limitacao de so serem atribuidos a metodos void
    public static Action<int> SelectSound;
    public static Action<string> EnterSound;
    public static Action<int> DeathSound;
    public static Action<string> AttackSound;
    public static Action<string> DamageSound;
    public static Action PutTrapSound;
    public static Action ActiveTrapSound;
    public static Action ManaSound;

    private AudioSource AS;
    [Header("MenuClips")]
    [SerializeField] private AudioClip navigateOption;
    [SerializeField] private AudioClip selectOption;
    [SerializeField] private AudioClip selectExitOption;
    [SerializeField] private AudioClip privateOption;
    [SerializeField] private AudioClip enterPlayerTurn;
    [SerializeField] private AudioClip enterBossTurn;
    [Header("AttackClips")]
    [SerializeField] private AudioClip[] attacks;
    [SerializeField] private AudioClip[] damages;
    [SerializeField] private AudioClip putTrap;
    [SerializeField] private AudioClip activeTrap;
    [SerializeField] private AudioClip mana;
    [Header("Other Configs")]
    [SerializeField] private Animator deathAnim;
    // Start is called before the first frame update
    private void OnEnable()
    {
        NavigateSound += PlayNavigateSound;
        SelectSound += PlaySelectSound;
        EnterSound += PlayEnterSound;
        DeathSound += PlayDeathSound;
        AttackSound += PlayAttackSound;
        DamageSound += PlayDamageSound;
        PutTrapSound += PlayPutTrapSound;
        ActiveTrapSound += PlayActiveTrapSound;
        ManaSound += PlayManaSound;
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
        else if (audio <= 2)//Senao
            AS.PlayOneShot(selectOption);//Tocar a opcao comum de selecao
        else
            AS.PlayOneShot(privateOption);
    }
    private void PlayEnterSound(string unitName)
    {
        if (unitName.StartsWith("Jogador"))
            AS.PlayOneShot(enterPlayerTurn);
        else if (unitName.StartsWith("Vilao"))
            AS.PlayOneShot(enterBossTurn);
        else
            Debug.LogError("Nome nao encontrado! Sem efeitos sonoros");
    }
    private void PlayDeathSound(int type)
    {
        if(type == 0)
            deathAnim.Play("PlayerDeathAudio");
        else
            deathAnim.Play("BossDeathAudio");
    }
    private void PlayAttackSound(string unitName)
    {
        switch (unitName)
        {
            case "Jogador 1": 
                AS.PlayOneShot(attacks[0]);
                break;
            case "Jogador 2":
                AS.PlayOneShot(attacks[1]);
                break;
            case "Jogador 3":
                AS.PlayOneShot(attacks[2]);
                break;
            case "Vilao":
                AS.PlayOneShot(attacks[3]);
                break;
            default: Debug.LogError("Nome nao encontrado! Sem efeitos sonoros");
                break;
        }
    }
    private void PlayDamageSound(string unitName)
    {
        StartCoroutine(WaitEndOfAttack(unitName));
    }

    IEnumerator WaitEndOfAttack(string unitName)
    {
        yield return new WaitForSeconds(attacks[0].length);
        if (unitName.StartsWith("Jogador"))
            AS.PlayOneShot(damages[0]);
        else if (unitName.StartsWith("Vilao"))
            AS.PlayOneShot(damages[0]);
        else
            Debug.LogError("Nome nao encontrado! Sem efeitos sonoros");
    }
    private void PlayPutTrapSound() { AS.PlayOneShot(putTrap); }
    private void PlayActiveTrapSound() { AS.PlayOneShot(activeTrap); }
    private void PlayManaSound() { AS.PlayOneShot(mana); }
    #endregion
    private void OnDisable()
    {
        NavigateSound -= PlayNavigateSound;
        SelectSound -= PlaySelectSound;
        EnterSound -= PlayEnterSound;
        DeathSound -= PlayDeathSound;
        AttackSound -= PlayAttackSound;
        DamageSound -= PlayDamageSound;
        PutTrapSound -= PlayPutTrapSound;
        ActiveTrapSound -= PlayActiveTrapSound;
        ManaSound -= PlayManaSound;

    }
}
