using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void Collect(int value)
    {
        GameManager.Instance.CollectCoin(value);
    }

    void DestroyMyself()
    {
        Destroy(this.gameObject);
    }
}
