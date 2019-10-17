using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombContact : MonoBehaviour
{

    public GameObject explosionAnim;
   

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
        if (collision.tag != "Collectable")
        {
            if (collision.GetComponent<Stone>() != null)
            {
                if (collision.isTrigger == false)
                {
                    collision.GetComponent<Stone>().Break();
                }

            }

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            RopeController RC = player.transform.GetChild(6).GetComponent<RopeController>();

            if (RC.rope != null)
            {
                if (RC.rope.connectedBody != null)
                {
                    if (RC.rope.connectedBody == GetComponent<Rigidbody2D>())
                    {
                        RC.rope = null;
                        Destroy(player.transform.GetChild(2).GetComponent<SpringJoint2D>());

                    }
                }
            }

            if (RC.ropeTwo != null)
            {
                if (RC.ropeTwo.connectedBody != null)
                {
                    if (RC.ropeTwo.connectedBody == GetComponent<Rigidbody2D>())
                    {
                        RC.rope = null;
                        Destroy(player.transform.GetChild(3).GetComponent<SpringJoint2D>());

                    }
                }
            }

            Instantiate(explosionAnim, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

            
        }


    }

}
