using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{

    public GameObject StarFollow;
    public bool collected;

    // Start is called before the first frame update
    void Start()
    {
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Body" && collected == false)
        {
            //transform.SetParent(collision.transform);
            //transform.localScale = new Vector3(5f / collision.transform.localScale.x, 5f / collision.transform.localScale.y, 5f / collision.transform.localScale.z);
            //collected = true;
            GameObject SF = Instantiate(StarFollow, transform.position, Quaternion.identity);
            //SF.transform.SetParent(collision.transform.parent.GetChild(0));
            SF.GetComponent<StarFollow>().ObjToFollow = collision.transform.parent.GetChild(1).gameObject;
            SF.GetComponent<StarFollow>().relativePos = transform.position - collision.transform.parent.GetChild(1).transform.position;
            
            Destroy(this.gameObject);
        }
    }

    
}
