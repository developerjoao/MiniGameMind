using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardObstacle : MonoBehaviour
{
    Animator obstacleAnimator;
    Collider obstacleCollider;

    void Start()
    {
        obstacleAnimator = GetComponent<Animator>();
        obstacleCollider = GetComponent<Collider>();
    }

    public void RemoveObstacle()
    {
        obstacleAnimator.SetBool("Cleared", true);
        obstacleCollider.enabled = false;
    }

    
}
