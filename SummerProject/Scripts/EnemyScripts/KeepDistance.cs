using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour
{

    public BehaviorControl BC;

    public float distance;

    public float speed;

    public GameObject player;

    

    // Start is called before the first frame update
    void Start()
    {
        BC = gameObject.GetComponent<BehaviorControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");

        }
        else if (BC.isKeepingDistance)
        {
            keepDistance();
        }

    }

    private void keepDistance()
    {
        // keep the character "distance" away from player horizontally and move to the same y-axis as the player so that the character can shoot at the player
        if (transform.position.x <= player.transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(player.transform.position.x - distance, player.transform.position.y, 0), speed * Time.deltaTime);
        }
        else if (transform.position.x > player.transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(player.transform.position.x + distance, player.transform.position.y, 0), speed * Time.deltaTime);
        }
    }
}
