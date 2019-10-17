using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private GameObject PlayerTorso;
    public float BottomBound;
    public float UpperBound;
    public float LeftBound;
    public float RightBound;

    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerTorso = player.transform.GetChild(1).gameObject;
            transform.position = new Vector3(PlayerTorso.transform.position.x, PlayerTorso.transform.position.y, -10f);
        }


        if (transform.position.y < BottomBound)
        {
            transform.position = new Vector3(transform.position.x, BottomBound, -10f);
        }
        if (transform.position.y > UpperBound)
        {
            transform.position = new Vector3(transform.position.x, UpperBound, -10f);
        }
        if (transform.position.x < LeftBound)
        {
            transform.position = new Vector3(LeftBound, transform.position.y, -10f);
        }
        if (transform.position.x > RightBound)
        {
            transform.position = new Vector3(RightBound, transform.position.y, -10f);
        }


        if (Input.mouseScrollDelta.y > 0 && mainCam.orthographicSize > 6)
        {
            mainCam.orthographicSize--;
        }
        else if (Input.mouseScrollDelta.y < 0 && mainCam.orthographicSize < 8)
        {
            mainCam.orthographicSize++;
        }

    }
}
