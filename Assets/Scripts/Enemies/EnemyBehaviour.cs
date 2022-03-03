using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    protected Animator enemyAnimator;
    public int health;

    void start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    public virtual void TakeDamage(int value)
    {
        health -= value;
        //play hit animation
        if(health <= 0)
        {
            //play death animation
            
        }
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
