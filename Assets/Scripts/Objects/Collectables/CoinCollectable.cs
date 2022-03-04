using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : CollectableBehaviour
{
    public int myValue;
    Animator collectableAnimator;
    Collider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        collectableAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            myCollider.enabled = false;
            collectableAnimator.SetBool("Collected", true);
            base.Collect(myValue);
        }
    }
}
