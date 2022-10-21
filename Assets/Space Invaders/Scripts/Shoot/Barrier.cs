using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour, IHealth
{
    [SerializeField] private int structure;
    public int health => structure;

    void IHealth.Damage(int damageRecieved)
    {
        structure -= damageRecieved;
        if(structure <= 0)
        {
            Destroy(gameObject);
        }
    }

    void IHealth.SetHealth(int value) => structure = value;

    
}
