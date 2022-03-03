using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health;

    public virtual void TakeDamage(int value)
    {
        health -= value;
    }
    
    protected void EnemyDeath()
    {
        Destroy(this.gameObject);
    }
}
