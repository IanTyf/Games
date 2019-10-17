using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sweat : MonoBehaviour
{

    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = parent.GetChild(0).transform.position;
    }
}
