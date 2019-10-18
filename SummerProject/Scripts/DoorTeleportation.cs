using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleportation : MonoBehaviour
{

    public string DoorDirection;

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
        if (collision.tag == "Player")
        {
            teleport(DoorDirection, collision.gameObject);
        }
        else if(collision.tag == "CanPassDoor")
        {
            //collision.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.attachedRigidbody);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CanPassDoor")
        {
            collision.gameObject.AddComponent<Rigidbody2D>().isKinematic = true;
            
        }
    }

    private void teleport(string direction, GameObject target)
    {
        Vector2 currentRoomPos = getCurrentRoomPos();
        switch (direction)
        {
            case "top":
                // teleport
                target.transform.position = currentRoomPos + new Vector2(0f, 10f);
                // update the player's field CurrentPosOnMatrix
                target.GetComponent<PlayerMovement>().CurrentRoomPosOnMatrix += new Vector2(-1, 0);
                break;
            case "down":
                // teleport
                target.transform.position = currentRoomPos + new Vector2(0f, -10.2f);
                // update the player's field CurrentPosOnMatrix
                target.GetComponent<PlayerMovement>().CurrentRoomPosOnMatrix += new Vector2(1, 0);
                break;
            case "right":
                // teleport
                target.transform.position = currentRoomPos + new Vector2(14.5f, 0f);
                // update the player's field CurrentPosOnMatrix
                target.GetComponent<PlayerMovement>().CurrentRoomPosOnMatrix += new Vector2(0, 1);
                break;
            case "left":
                // teleport
                target.transform.position = currentRoomPos + new Vector2(-14.5f, 0f);
                // update the player's field CurrentPosOnMatrix
                target.GetComponent<PlayerMovement>().CurrentRoomPosOnMatrix += new Vector2(0, -1);
                break;
        }
    }

    
    // returns the position of the current room
    private Vector2 getCurrentRoomPos()
    {
        return this.transform.parent.position;
    }
}
