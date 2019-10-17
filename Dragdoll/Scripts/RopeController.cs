using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public bool ropeLock;

    public GameObject ropeShooterOne;
    public GameObject ropeShooterTwo;

    public SpringJoint2D rope;
    public SpringJoint2D ropeTwo;

    public LineRenderer LR;
    public LineRenderer LRTwo;

    private void Start()
    {
        ropeLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ropeLock)
        {

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.A))
            {
                if (rope != null)
                {
                    stopLeaking("left");
                    DestroyImmediate(rope);
                }
                else
                {
                    Shoot(ropeShooterOne.transform.position, ropeShooterOne);
                }
            }
            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.D))
            {
                if (ropeTwo != null)
                {
                    stopLeaking("right");
                    DestroyImmediate(ropeTwo);
                }
                else
                {
                    Shoot(ropeShooterTwo.transform.position, ropeShooterTwo);
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (rope!= null)
        {
            LR.enabled = true;
            
            LR.SetPosition(0, ropeShooterOne.transform.position);

            if (rope.connectedBody == null)
            {
                LR.SetPosition(1, rope.connectedAnchor);
            }
            else
            {
                LR.SetPosition(1, rope.connectedBody.GetRelativePoint(rope.connectedAnchor));
            }
      
        }
        else
        {
            LR.enabled = false;
        }

        if (ropeTwo != null)
        {
            LRTwo.enabled = true;
            
            LRTwo.SetPosition(0, ropeShooterTwo.transform.position);

            if (ropeTwo.connectedBody == null)
            {
                LRTwo.SetPosition(1, ropeTwo.connectedAnchor);
            }
            else
            {
                LRTwo.SetPosition(1, ropeTwo.connectedBody.GetRelativePoint(ropeTwo.connectedAnchor));
            }
        }
        else
        {
            LRTwo.enabled = false;
        }
    }

    public void Shoot(Vector2 shootFrom, GameObject shooter)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - shootFrom;

        RaycastHit2D hit = Physics2D.Raycast(shootFrom, dir, 10f);
        Debug.Log("Raycasted");

        if (hit.collider != null && hit.collider.tag == "Stickable")
        {
            Debug.Log("Hit");
            SpringJoint2D newRp = shooter.AddComponent<SpringJoint2D>();

            if (hit.collider.attachedRigidbody != null)
            {
                newRp.connectedBody = hit.collider.attachedRigidbody;
                newRp.autoConfigureConnectedAnchor = false;
                newRp.connectedAnchor = hit.collider.attachedRigidbody.GetPoint(hit.point);
            }
            else
            {
                newRp.autoConfigureConnectedAnchor = false;
                newRp.connectedAnchor = hit.point;
            }

            newRp.enableCollision = true;
            newRp.autoConfigureDistance = false;
            newRp.distance = hit.distance * 0.3f;
            //newRp.connectedAnchor = hit.point;
            newRp.frequency = 1f;
            //newRp.autoConfigureConnectedAnchor = false;
            newRp.enabled = true;


            string hand = "";
            if (shooter == ropeShooterOne)
            {
                GameObject.DestroyImmediate(rope);
                rope = newRp;
                hand = "left";
            }
            else if (shooter == ropeShooterTwo)
            {
                GameObject.DestroyImmediate(ropeTwo);
                ropeTwo = newRp;
                hand = "right";
            }


            if (hit.collider.gameObject.GetComponent<SandBehavior>() != null)
            {
                hit.collider.gameObject.GetComponent<SandBehavior>().Leak(hit.point, hand);
            }


        }
    }

    private void stopLeaking(string whichHand)
    {
        GameObject[] LEs = GameObject.FindGameObjectsWithTag("SandLeakEffect");
        foreach (GameObject le in LEs)
        {
            if (le.GetComponent<LeakEffect>().whichHand == whichHand)
            {
                le.GetComponent<LeakEffect>().End();
            }
        }
    }

}
