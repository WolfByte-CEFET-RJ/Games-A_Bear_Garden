using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimController : MonoBehaviour
{
    [SerializeField] private Unit arqueiro;
    [SerializeField] private Unit guerreiro;
    [SerializeField] private Unit mago;
    [SerializeField] private Unit vilao;
    public delegate Unit GetUnit(int i);
    public static GetUnit GetUnitPrefab;

    #region Codigo apagado
    //[Header("AnimControllers")]
    //[SerializeField] private RuntimeAnimatorController arqueiro;
    //[SerializeField] private RuntimeAnimatorController guerreiro;
    //[SerializeField] private RuntimeAnimatorController mago;
    //[SerializeField] private RuntimeAnimatorController vilao;

    //public delegate RuntimeAnimatorController SetAnim(int i);
    //public static SetAnim SetAnimController;
    //private void OnEnable()
    //{
    //    SetAnimController += SetAnimatorController;
    //}
    //private void OnDisable()
    //{
    //    SetAnimController -= SetAnimatorController;
    //}
    //// Update is called once per frame
    //void Update()
    //{

    //}
    //private RuntimeAnimatorController SetAnimatorController(int i)
    //{
    //    //switch (i)
    //    //{
    //    //    case 0: return arqueiro;
    //    //    case 1: return guerreiro;
    //    //    case 2: return mago;
    //    //    default: return vilao;
    //    //}
    //    return guerreiro;
    //}
    #endregion

    public static Action<Animator, int> SetInt;
    public static Action<Animator, string> SetTrigger;
    private void OnEnable()
    {
        SetInt += SetAnimatorInt;
        SetTrigger += SetAtimatorTrigger;
        GetUnitPrefab += getUnitPrefab;
    }
    private void OnDisable()
    {
        SetInt -= SetAnimatorInt;
        SetTrigger -= SetAtimatorTrigger;
        GetUnitPrefab -= getUnitPrefab;
    }
    private void SetAnimatorInt(Animator anim, int i)
    {
        anim.SetInteger("trans", i);
    }
    private void SetAtimatorTrigger(Animator anim, string key)
    {
        anim.SetTrigger(key);
    }

    private Unit getUnitPrefab(int i)
    {
        switch(i)
        {
            case 0: return arqueiro;
            case 1: return guerreiro;
            case 2: return mago;
            default: return vilao;
        }
    }
}
