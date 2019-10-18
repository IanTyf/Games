using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;

    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        switch (direction)
        {
            case 2:
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                break;
            case 0:
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                break;
            case 3:
                transform.Translate(Vector2.up * speed * Time.deltaTime);
                break;
            case 1:
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                break;
        }
    }
}
