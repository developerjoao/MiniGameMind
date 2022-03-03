using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel_Enemy : EnemyBehaviour
{
    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);
    }

    public void ResetHitAnim()
    {
        enemyAnimator.SetBool("Hit", false);
    }
}
