using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardObstacle : MonoBehaviour
{
    Animator obstacleAnimator;
    Collider obstacleCollider;

    public GameObject myCamera;

    void Start()
    {
        obstacleAnimator = GetComponent<Animator>();
        obstacleCollider = GetComponent<Collider>();

        myCamera.SetActive(false);
    }

    public void RemoveObstacle()
    {
        myCamera.SetActive(true);
        GameManager.Instance.DisablePlayer();
        obstacleAnimator.SetBool("Cleared", true);
        obstacleCollider.enabled = false;
    }

    public void disableObstacleCamera()
    {
        myCamera.SetActive(false);
        GameManager.Instance.EnablePlayer();
    }    
}
