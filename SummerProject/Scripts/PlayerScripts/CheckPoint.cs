using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public bool collided;

    public string collidedWith;

    public GameObject collidedObj;

    // Start is called before the first frame update
    void Start()
    {
        collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided!");
        collided = true;
        if (collision.tag == "Dead")
        {
            collidedWith = "Dead";
            collidedObj = collision.gameObject;
        }
    }
}
