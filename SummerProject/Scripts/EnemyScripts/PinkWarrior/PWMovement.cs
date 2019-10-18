using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWMovement : MonoBehaviour, Behaviors
{

    public int facing;

    public float speed;

    public GameObject deadBody;

    public GameObject player;


    public bool isChasing;
    public bool isThrowingAxe;
    public bool isPickingUpAxe;

    public PWSpells mySpells;

    public GameObject closestAxe;

    public GameObject axePrefab;

    public bool freezeMovement;

    public Animator anim;

    public GameObject[] DeadBodies;

    private Color defaultColor;

    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        mySpells = GetComponent<PWSpells>();
        //player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        defaultColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //if (Input.GetKeyDown(KeyCode.Y)) Die();

        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        rb2d.velocity = Vector2.zero;

        if (playerInSameRoom() && !freezeMovement)
        {
            if (mySpells.hasAxe)
            {
                if (Mathf.Abs(transform.position.x - player.transform.position.x) >= 4 && Mathf.Abs(transform.localPosition.x) < 6 && Mathf.Abs(transform.localPosition.y) < 2.5)
                {
                    throwAxe();
                    
                }
                else
                {
                    swingHammer();
                }
            }
            else
            {
                // get the closest axe in the room
                GameObject[] axes = GameObject.FindGameObjectsWithTag("AxeOnWall");
                foreach (GameObject axe in axes)
                {
                    if (axe.transform.parent == transform.parent)
                    {
                        if (closestAxe == null) closestAxe = axe;
                        else
                        {
                            if (Vector2.Distance(transform.position, axe.transform.position) < Vector2.Distance(transform.position, closestAxe.transform.position))
                            {
                                closestAxe = axe;
                            }
                        }
                    }
                }

                // if he's closer to axe, pick it up. otherwise, go attack the player
                if (closestAxe == null) swingHammer();
                else if (Vector2.Distance(transform.position, closestAxe.transform.position) > Vector2.Distance(transform.position, player.transform.position)) 
                {
                    swingHammer();
                }
                else
                {
                    pickUpAxe();
                }
            }
        }
    }

    public void Die()
    {
        anim.SetBool("isDead", true);
        //StopCoroutine(mySpells.releaseAxeCo);
        speed = 0;

        StartCoroutine(CreateDeadBody(transform.GetChild(1).childCount > 0));
    }

    // Body turns red for a tiny short while
    public void GetHit()
    {
        SpriteRenderer SR = transform.GetChild(0).GetComponent<SpriteRenderer>();
        SR.color = Color.red;
        StartCoroutine(changeColorAfterSeconds(SR,0.1f));
    }

    IEnumerator changeColorAfterSeconds(SpriteRenderer SR,float time)
    {
        yield return new WaitForSeconds(time);
        SR.color = defaultColor;
    }

    IEnumerator CreateDeadBody(bool hasAxe)
    {
        yield return new WaitForSeconds(1f);
        if (hasAxe)
        {
            GameObject body = Instantiate(DeadBodies[0], transform.position, Quaternion.identity, transform.parent);
            body.transform.localScale = new Vector3(body.transform.localScale.x * (transform.localScale.x / Mathf.Abs(transform.localScale.x)), body.transform.localScale.y, body.transform.localScale.z);

        }
        else
        {
            GameObject body = Instantiate(DeadBodies[1], transform.position, Quaternion.identity, transform.parent);
            body.transform.localScale = new Vector3(body.transform.localScale.x * (transform.localScale.x / Mathf.Abs(transform.localScale.x)), body.transform.localScale.y, body.transform.localScale.z);

        }
        Destroy(this.gameObject);
    }

    IEnumerator disableFreeze(float time)
    {
        yield return new WaitForSeconds(time);
        freezeMovement = false;
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

    private void swingHammer()
    {
        Vector2 oldPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (transform.position.x > oldPos.x) facing = 1;
        else if (transform.position.x < oldPos.x) facing = -1;

        if (facing != 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * facing, transform.localScale.y, transform.localScale.z);
        }

        if (Vector2.Distance(transform.position, player.transform.position) < 1.5f)
        {
            mySpells.castFirstSpell();
        }
    }

    private void throwAxe()
    {
        // first, try to move to the same y pos as the player
        
        //Vector2 oldPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, player.transform.position.y), speed * Time.deltaTime);

        //if (transform.position.x > oldPos.x) facing = 1;
        //else if (transform.position.x < oldPos.x) facing = -1;
        if (player.transform.position.x > transform.position.x)
        {
            facing = 1;
        }
        else if (player.transform.position.x < transform.position.x)
        {
            facing = -1;
        }

        

        if (facing != 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * facing, transform.localScale.y, transform.localScale.z);
        }

        // once does so, throw the axe (second spell)
        if (transform.position.y == player.transform.position.y)
        {
            mySpells.castSecondSpell();
            freezeMovement = true;
            StartCoroutine(disableFreeze(mySpells.getSecondSpellLength()));
        }
    }

    private void pickUpAxe()
    {
        Vector2 oldPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, closestAxe.transform.position, speed * Time.deltaTime);
        if (transform.position.x > oldPos.x) facing = 1;
        else if (transform.position.x < oldPos.x) facing = -1;

        if (facing != 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * facing, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AxeOnWall" && mySpells.hasAxe == false)
        {
            Transform rightArm = transform.GetChild(1);
            GameObject ax = Instantiate(axePrefab, transform.position, Quaternion.identity, rightArm);
            ax.GetComponent<AxeDamage>().myself = this.gameObject;
            mySpells.hasAxe = true;
            Destroy(collision.gameObject);
        }
    }
}
