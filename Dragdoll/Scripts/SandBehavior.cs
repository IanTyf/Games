using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBehavior : MonoBehaviour
{

    public GameObject LeakEffect;
    public GameObject BreakEffect;

    public float leakCounter;

    public float breakAfterSeconds;

    public bool isLeftHandLeaking;
    public bool isRightHandLeaking;

    public bool hasShownPlayerLeak;

    private GameObject playerLeakEffect;

    // Start is called before the first frame update
    void Start()
    {
        isLeftHandLeaking = false;
        isRightHandLeaking = false;
        hasShownPlayerLeak = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeftHandLeaking)
        {
            leakCounter += Time.deltaTime;
            Color oldColor = this.GetComponent<SpriteRenderer>().color;
            this.GetComponent<SpriteRenderer>().color = new Color(oldColor.r, oldColor.g, oldColor.b, (10 - leakCounter) / 10f);
        }

        if (isRightHandLeaking)
        {
            leakCounter += Time.deltaTime;
            Color oldColor = this.GetComponent<SpriteRenderer>().color;
            this.GetComponent<SpriteRenderer>().color = new Color(oldColor.r, oldColor.g, oldColor.b, (10 - leakCounter) / 10f);
        }

        if (hasShownPlayerLeak)
        {
            leakCounter += Time.deltaTime;
            Color oldColor = this.GetComponent<SpriteRenderer>().color;
            this.GetComponent<SpriteRenderer>().color = new Color(oldColor.r, oldColor.g, oldColor.b, (10 - leakCounter) / 10f);
        }


        if (leakCounter > breakAfterSeconds)
        {
            Instantiate(BreakEffect, transform.position, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            RopeController RC = player.transform.GetChild(6).GetComponent<RopeController>();
            if (isLeftHandLeaking)
            {
                RC.rope = null;
                Destroy(player.transform.GetChild(2).GetComponent<SpringJoint2D>());

            }
            if (isRightHandLeaking)
            {
                RC.ropeTwo = null;
                Destroy(player.transform.GetChild(3).GetComponent<SpringJoint2D>());
            }


            Destroy(this.gameObject);
        }
    }

    public void Leak(Vector2 pos, string whichHand)
    {
        GameObject LE = Instantiate(LeakEffect, pos, Quaternion.identity);
        LE.transform.SetParent(transform);
        LE.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        LE.GetComponent<LeakEffect>().whichHand = whichHand;
        LE.GetComponent<LeakEffect>().theSand = this.gameObject;
        if (whichHand == "left") isLeftHandLeaking = true;
        else if (whichHand == "right") isRightHandLeaking = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Body")
        {
            if (!hasShownPlayerLeak)
            {
                GameObject LE = Instantiate(LeakEffect, new Vector3(collision.transform.position.x, transform.position.y+0.47f, transform.position.z - 1), Quaternion.identity);
                LE.transform.SetParent(transform);
                LE.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
                playerLeakEffect = LE;

                hasShownPlayerLeak = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Body")
        {
            if (hasShownPlayerLeak)
            {
                playerLeakEffect.GetComponent<LeakEffect>().End();
                playerLeakEffect = null;
                hasShownPlayerLeak = false;
            }
        }
    }



}
