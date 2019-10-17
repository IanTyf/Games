using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyAfterSeconds : MonoBehaviour
{

    public float DestroyAfterSeconds;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, DestroyAfterSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
