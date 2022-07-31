using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Unit : MonoBehaviour
{
    [HideInInspector]
    public Stats stats;
    void Awake()
    {
        stats = GetComponentInChildren<Stats>();// informações será armazenada no stats do personagem no Objeto filho 
    }
}