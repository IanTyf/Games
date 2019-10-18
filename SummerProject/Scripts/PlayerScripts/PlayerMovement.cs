using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int facing;

    public float moveSpeed;

    public Rigidbody2D rb2D;

    public Vector2 CurrentRoomPosOnMatrix = new Vector2(2,2);

    public float defaultMoveSpeed;

    public bool isMoving;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -1 * (int)(transform.position.y*10);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        move();

        if (transform.childCount == 0)
        {
            moveSpeed = defaultMoveSpeed;
        }
        
    }

    private void move()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalMovement, verticalMovement);
        movement.Normalize();
        //transform.Translate(Vector3.right * horizontalMovement * moveSpeed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalMovement * moveSpeed * Time.deltaTime);

        isMoving = (movement != Vector2.zero);


        rb2D.velocity = movement * moveSpeed;
        
        if (horizontalMovement > 0)
        {
            facing = 1;
        }
        else if (horizontalMovement < 0)
        {
            facing = -1;
        }

    }

    
}
