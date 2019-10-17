using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEdge : MonoBehaviour
{
    public string LRorTD;

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
        if (collision.tag == "Body")
        {
            Rigidbody2D rb2d = collision.GetComponent<Rigidbody2D>();
            if (LRorTD == "LR") {
                rb2d.AddForce(new Vector2(rb2d.velocity.x * -2 + 5f * -(rb2d.velocity.x/Mathf.Abs(rb2d.velocity.x)), 0), ForceMode2D.Impulse);
                
            }
            else if (LRorTD == "TD")
            {
                rb2d.AddForce(new Vector2(0, rb2d.velocity.y * -2 + 5f * -(rb2d.velocity.y / Mathf.Abs(rb2d.velocity.y))), ForceMode2D.Impulse);
            }
            Debug.Log("pushing");
        }
    }

}
