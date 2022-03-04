using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine_Enemy : EnemyBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.collider.GetComponent<PlayerBehaviour>().TakeDamage();
            GameManager.Instance.UpdateHeart(true);
        }
    }
}
