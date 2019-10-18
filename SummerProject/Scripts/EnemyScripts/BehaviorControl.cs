using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorControl : MonoBehaviour
{
    public int facing;

    public bool isChasing;

    public bool isKeepingDistance;

    public bool isShooting;

    // the time that a "wave" of shots lasts
    public float keepShootingSeconds;

    // the time between 2 waves of shots
    public float shootingCD;

    // the time between 2 shots
    public float shotGap;


    public GameObject player;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = Vector2.zero;
        if (playerInSameRoom())
        {
            // adapt facing
            if (transform.position.x <= player.transform.position.x)
            {
                facing = 1;
            }
            else if (transform.position.x > player.transform.position.x)
            {
                facing = -1;
            }

            // let it do ranged attack
            isKeepingDistance = true;
            isShooting = true;
        }
        else
        {
            isShooting = false;
            isKeepingDistance = false;
        }
    }

    private bool playerInSameRoom()
    {
        Vector2 myRoomPos = this.transform.parent.transform.position;
        Vector2 playerMatrixPos = player.GetComponent<PlayerMovement>().CurrentRoomPosOnMatrix;
        float playerRoomPosX = (playerMatrixPos.y - 2) * 21f;
        float playerRoomPosY = -(playerMatrixPos.x - 2) * 13f;
        Vector2 playerRoomPos = new Vector2(playerRoomPosX, playerRoomPosY);
        return (myRoomPos == playerRoomPos);
    }
}
