using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    Animator collectableAnimator;
    Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        collectableAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collectableAnimator.SetBool("Collected", true);
            myCollider.enabled = false;
        }
    }

    void DestroyMyself()
    {
        Destroy(this.gameObject);
    }
}
