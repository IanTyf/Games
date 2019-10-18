using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float RawDamage;

    public float ExplosionDelay;

    private float counter;

    public bool StartCounting;

    public GameObject ExplosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCounting)
        {
            counter += Time.deltaTime;
        }

        if (counter >= ExplosionDelay)
        {
            Explode();
        }
    }

    public void Explode()
    {
        
        GameObject explosion = Instantiate(ExplosionEffect, transform.position, Quaternion.identity, transform.parent);
        explosion.GetComponent<GSGExplosion>().RawDamage = RawDamage;
        Destroy(this.gameObject);
    }



}
