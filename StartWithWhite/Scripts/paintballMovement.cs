using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintballMovement : MonoBehaviour
{

    public Vector2 target;
    public float speed;

    public GameObject ExplodeEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            Destroy(this.gameObject);
        }
    }

    public void Explode()
    {
        GameObject EE = Instantiate(ExplodeEffect, transform.position, Quaternion.identity);
        var main = EE.GetComponent<ParticleSystem>().main;
        main.startColor = this.GetComponent<SpriteRenderer>().color;
        Destroy(this.gameObject);
    }
}
