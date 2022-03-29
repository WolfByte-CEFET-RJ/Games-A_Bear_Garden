using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth 
{
    int health { get; }

    void SetHealth(int value);
    void Damage(int damageRecieved);
}
