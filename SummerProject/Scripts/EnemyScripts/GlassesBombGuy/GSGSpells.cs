using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSGSpells : MonoBehaviour, Spells
{

    public Animator anim;

    public GameObject bomb;

    public bool firstSpellLock;
    public bool secondSpellLock;

    public float firstSpellLength;
    public float secondSpellLength;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool castFirstSpell()
    {
        Debug.Log("Bomb planted...");
        
        anim.SetBool("plant", true);


        // get the room that it's currently in
        // make it the child of this room after certain seconds
        // let it explode
        
        // firstly, if it's still an enemy
        
        if (this.transform.parent.tag == "Room")
        {
            // put down the bomb with parameter being the room that this enemy is currently in
            StartCoroutine(putBombDown(transform.parent.gameObject));
        }

        // or if it's cast by a player
        else if (this.transform.parent.tag == "Player")
        {
            // find the room that player is currently in
            PlayerMovement PM = this.transform.parent.GetComponent<PlayerMovement>();
            Vector2 playerMatrixPos = PM.CurrentRoomPosOnMatrix;
            float playerRoomPosX = (playerMatrixPos.y - 2) * 21f;
            float playerRoomPosY = -(playerMatrixPos.x - 2) * 13f;
            Vector3 playerRoomPos = new Vector3(playerRoomPosX, playerRoomPosY, 0);
            RoomManager RM = GameObject.Find("RoomManager").GetComponent<RoomManager>();
            GameObject playerRoom = null;
            foreach (GameObject rm in RM.rooms)
            {
                if (rm.transform.position == playerRoomPos)
                {
                    playerRoom = rm;
                }
            }
            // put down the bomb with parameter being the room the player is in while using this move
            StartCoroutine(putBombDown(playerRoom));
        }
        

        StartCoroutine(finishPlant());

        return firstSpellLock;
    }

    public bool castSecondSpell()
    {
        Debug.Log("No second spell...");
        return false;
    }

    public float getFirstSpellLength()
    {
        return firstSpellLength;
    }

    public float getSecondSpellLength()
    {
        return secondSpellLength;
    }


    IEnumerator finishPlant()
    {
        yield return new WaitForSeconds(1.2f);
        anim.SetBool("plant", false);
    }

    IEnumerator putBombDown(GameObject rm)
    {
        yield return new WaitForSeconds(0.6f);
        
        //Bomb bomb = transform.GetChild(0).gameObject.GetComponent<Bomb>();
        //bomb.Explode();
        //transform.GetChild(0).SetParent(rm.transform);
        if (transform.childCount != 0)
        {
            GameObject child = transform.GetChild(0).gameObject;
            Vector3 pos = child.transform.position;
            Destroy(child);
            GameObject bm = Instantiate(bomb, pos, Quaternion.identity, rm.transform);
            bm.transform.localScale = new Vector3(bm.transform.localScale.x * (transform.localScale.x / Mathf.Abs(transform.localScale.x)), bm.transform.localScale.y, bm.transform.localScale.z);
            bm.GetComponent<Bomb>().StartCounting = true;
        }



        anim.SetBool("hasBomb", false);

    }
}
