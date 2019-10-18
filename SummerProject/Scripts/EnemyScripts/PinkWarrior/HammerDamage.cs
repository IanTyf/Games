using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerDamage : MonoBehaviour
{
    public float RawDamage;

    public GameObject myself;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Enemy" || collision.tag == "Attached") && collision.gameObject != myself)
        {
            DamageManager DM = GameObject.Find("DamageManager").GetComponent<DamageManager>();
            DM.DealDamage(this.gameObject, collision.gameObject, RawDamage);

            
        }
    }
}
