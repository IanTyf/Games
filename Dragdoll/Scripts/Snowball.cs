using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public float destroyAfterSeconds;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();


        Destroy(this.gameObject, destroyAfterSeconds);
    }


    private void Update()
    {

        rb2d.mass = transform.localScale.x;


        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
    }

}
