using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : CollectableBehaviour
{
    public int myValue;
    Animator collectableAnimator;
    Collider myCollider;
    AudioSource myAudioSource;
    public AudioClip collectCoinSound;
    // Start is called before the first frame update
    void Start()
    {
        collectableAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            myCollider.enabled = false;
            collectableAnimator.SetBool("Collected", true);
            myAudioSource.PlayOneShot(collectCoinSound, 0.7f);
            base.Collect(myValue);
        }
    }
}
