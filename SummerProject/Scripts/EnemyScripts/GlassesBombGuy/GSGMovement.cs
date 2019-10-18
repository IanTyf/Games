using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSGMovement : MonoBehaviour, Behaviors
{

    public float speed;
    public int facing;

    public GameObject player;

    public Animator anim;

    public bool hasBomb;

    public Vector3 escapeTo;

    public bool moveAway;

    public bool stopMoving;

    public GameObject deadBody;

    private Color defaultColor;

    private bool canPlant;

    //public SpriteRenderer SR;

    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        moveAway = false;
        escapeTo = Vector3.zero;
        hasBomb = true;
        canPlant = false;
        //player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        defaultColor = GetComponent<SpriteRenderer>().color;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y);
        rb2d.velocity = Vector2.zero;

        player = GameObject.FindGameObjectWithTag("Player");

        if (playerInSameRoom())
        {
            // first, walk to the center of the room
            if (transform.position.x != transform.parent.transform.position.x && transform.position.y != transform.parent.transform.position.y && hasBomb == true && canPlant==false)
            {
                MoveToMiddleOfRoom();
                if (transform.position.x == transform.parent.transform.position.x && transform.position.y == transform.parent.transform.position.y) canPlant = true;
            }
            // then, drop the bomb
            else if (canPlant && hasBomb == true)
            {
                anim.SetBool("isWalking", false);
                Spells spells = GetComponent<GSGSpells>();
                spells.castFirstSpell();

                hasBomb = false;
                StartCoroutine(dropingBomb());
            }
            
        }

        if (moveAway == true)
        {
            if (escapeTo == Vector3.zero)
            {
                while (Vector3.Distance(escapeTo, Vector3.zero) < 3)
                {
                    float x = Random.Range(-5f, 5f);
                    float y = Random.Range(-2.5f, 2.5f);
                    float z = y;
                    escapeTo = new Vector3(x, y, z);
                }
            }
            MoveToMiddleOfRoom(escapeTo);

            if (transform.localPosition.x == escapeTo.x && transform.localPosition.y == escapeTo.y)
            {
                //moveAway = false;
                //anim.SetBool("isWalking", false);
                //Die();
                float x = Random.Range(-5f, 5f);
                float y = Random.Range(-2.5f, 2.5f);
                float z = y;
                escapeTo = new Vector3(x, y, z);
            }
        }
    }

    IEnumerator dropingBomb()
    {
        yield return new WaitForSeconds(1.2f);
        moveAway = true;
    }

    private bool playerInSameRoom()
    {
        if (player != null)
        {
            Vector2 myRoomPos = this.transform.parent.transform.position;
            Vector2 playerMatrixPos = player.GetComponent<PlayerMovement>().CurrentRoomPosOnMatrix;
            float playerRoomPosX = (playerMatrixPos.y - 2) * 21f;
            float playerRoomPosY = -(playerMatrixPos.x - 2) * 13f;
            Vector2 playerRoomPos = new Vector2(playerRoomPosX, playerRoomPosY);
            return (myRoomPos == playerRoomPos);
        }
        else return false;
    }

    public void MoveToMiddleOfRoom()
    {
        // move and update facing
        Vector2 oldPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, transform.parent.transform.position, speed * Time.deltaTime);
        if (transform.position.x > oldPos.x) facing = 1;
        else if (transform.position.x < oldPos.x) facing = -1;

        if (facing != 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * facing, transform.localScale.y, transform.localScale.z);
        }

        // play "walk" animation
        anim.SetBool("isWalking", true);
    }

    public void MoveToMiddleOfRoom(Vector3 target)
    {
        // move and update facing
        Vector2 oldPos = transform.position;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);
        if (transform.position.x > oldPos.x) facing = 1;
        else if (transform.position.x < oldPos.x) facing = -1;

        if (facing != 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * facing, transform.localScale.y, transform.localScale.z);
        }

        // play "walk" animation
        
        anim.SetBool("isWalking", true);
    }


    public void Die()
    {
        //play die animation
        anim.SetBool("isDead", true);

        //destroy the bomb if still in hand
        if (transform.childCount != 0) Destroy(this.transform.GetChild(0).gameObject);

        //Instantiate a dead body at the end of animation
        //destroy itself at the end of animation
        StartCoroutine(createDeadBody());
    }

    IEnumerator createDeadBody()
    {
        yield return new WaitForSeconds(1f);
        Vector3 tempPos = transform.position;
        GameObject body = Instantiate(deadBody, tempPos, Quaternion.identity, transform.parent);
        body.transform.localScale = new Vector3(body.transform.localScale.x * (transform.localScale.x / Mathf.Abs(transform.localScale.x)), body.transform.localScale.y, body.transform.localScale.z);
        Destroy(this.gameObject);
    }

    // Body turns red for a tiny short while
    public void GetHit()
    {
        SpriteRenderer SR = transform.GetComponent<SpriteRenderer>();
        
        SR.color = Color.red;
        StartCoroutine(changeColorAfterSeconds(SR, 0.1f));
    }

    IEnumerator changeColorAfterSeconds(SpriteRenderer SR, float time)
    {
        yield return new WaitForSeconds(time);
        SR.color = defaultColor;
    }
}
