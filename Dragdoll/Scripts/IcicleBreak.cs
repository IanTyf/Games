using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleBreak : MonoBehaviour
{

    public GameObject breakEffect;

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
        if (collision.GetComponent<Snowball>() != null)
        {
            if (transform.GetChild(0).gameObject.activeSelf == false)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (transform.GetChild(1).gameObject.activeSelf == false)
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                Instantiate(breakEffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
