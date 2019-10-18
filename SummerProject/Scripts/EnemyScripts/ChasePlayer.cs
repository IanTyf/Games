using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{

    public BehaviorControl BC;

    public GameObject player;

    public float speed;

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

        else if (BC.isChasing)
        {
            chase();
        }
    }

    private void chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
