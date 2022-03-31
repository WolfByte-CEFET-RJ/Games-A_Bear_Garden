using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : Collider, ICollider
{
    public override void GetHit()
    {
        var dano = GetComponentInParent<IHealth>();
        dano.Damage(10);
        Debug.Log("player hit");
    }
}
