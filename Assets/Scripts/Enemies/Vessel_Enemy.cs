using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel_Enemy : EnemyBehaviour
{
    [SerializeField]
    Animator enemyAnimator;

    public StandardObstacle vineWall;
    

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);
        enemyAnimator.SetBool("Hit", true);
    }

    public void ResetEnemyHitAnim()
    {
        enemyAnimator.SetBool("Hit", false);
        if(health <= 0)
        {
            vineWall.RemoveObstacle();
            enemyAnimator.SetBool("Dead", true);
        }
    }

}
