using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSGExplosion : MonoBehaviour
{

    public float RawDamage;



    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 4f);
        StartCoroutine(ActivateCollider());
        StartCoroutine(DisableCollider());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Attached")
        {
            DamageManager DM = GameObject.Find("DamageManager").GetComponent<DamageManager>();
            DM.DealDamage(this.gameObject, collision.gameObject, RawDamage);
        }
    }

    IEnumerator ActivateCollider()
    {
        yield return new WaitForSeconds(0.6f);
        this.transform.GetComponent<CircleCollider2D>().enabled = true;

    }

    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(0.8f);
        this.transform.GetComponent<CircleCollider2D>().enabled = false;
    }
}
