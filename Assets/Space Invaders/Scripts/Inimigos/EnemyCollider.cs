using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : Collider
{
    [SerializeField] private int shootDamage; 
    public override void GetHit()
    {
        var enemyHealth = gameObject.GetComponentInParent<IHealth>();
        if (enemyHealth != null)
            enemyHealth.Damage(shootDamage);
    }
}
