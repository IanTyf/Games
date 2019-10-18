using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoomFollow : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    private void followPlayer()
    {
        PlayerMovement pM = player.GetComponent<PlayerMovement>();
        float xpos = (pM.CurrentRoomPosOnMatrix.y - 2) * 21f;
        float ypos = -(pM.CurrentRoomPosOnMatrix.x - 2) * 13f;
        Vector3 cameraPos = new Vector3(xpos, ypos, -10);
        transform.position = cameraPos;
    }
}
