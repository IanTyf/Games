using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFollow : MonoBehaviour
{

    public GameObject ObjToFollow;

    public Vector3 relativePos;

    public Vector2 targetPos;
    public Vector2 boxPos;

    public float flyToTargetSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = ObjToFollow.transform.position + relativePos;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjToFollow != null)
        {
            transform.position = ObjToFollow.transform.position + relativePos;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, flyToTargetSpeed*Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPos) < 0.01f)
            {
                targetPos = boxPos;
            }

            flyToTargetSpeed += Time.deltaTime;
        }
    }

    // lets the starFollow flies into the box
    public void flyToBox(Vector3 boxPosition)
    {
        targetPos = transform.position + (transform.position - boxPosition);
        boxPos = boxPosition;
        ObjToFollow = null;

    }
}
