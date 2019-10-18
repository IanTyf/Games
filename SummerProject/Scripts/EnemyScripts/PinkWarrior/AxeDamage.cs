using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDamage : MonoBehaviour
{
    public float RawDamage;

    public float minDamage;

    public GameObject hitEffect;

    public GameObject myself;

    
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Enemy" || collision.tag == "Attached") && (collision.gameObject != myself))
        {
            DamageManager DM = GameObject.Find("DamageManager").GetComponent<DamageManager>();
            DM.DealDamage(this.gameObject, collision.gameObject, RawDamage);

            GameObject HE = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(HE, 1f);
        }
    }
}
