using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float DestroyAfterSeconds;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, DestroyAfterSeconds);
    }
    
    
}
