using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBody : MonoBehaviour
{
    public GameObject newBodyOnPlayer;

    public Vector3 pivotOffset;

    public GameObject getAlive()
    {
        // instantiate a children of player
        GameObject player = GameObject.Find("Player");

        GameObject obj = Instantiate(newBodyOnPlayer, player.transform.position, Quaternion.identity, player.transform);
        obj.transform.localPosition = Vector3.zero;

        // destroy itself
        Destroy(this.gameObject);

        return obj;

    }
}
