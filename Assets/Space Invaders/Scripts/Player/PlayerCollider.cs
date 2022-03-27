using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : Collider, ICollider
{
    public override void GetHit()
    {
        Debug.Log("player hit");
    }
}
