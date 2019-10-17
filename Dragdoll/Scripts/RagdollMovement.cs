using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollMovement : MonoBehaviour
{

    public Rigidbody2D torsoRB2d;
    public Rigidbody2D headRB2d;
    public Rigidbody2D leftArmRB2d;
    public Rigidbody2D rightArmRB2d;
    public Rigidbody2D leftLegRB2d;
    public Rigidbody2D rightLegRB2d;

    public bool canJump;

    public bool isInSpace;

    private RegionManager RM;

    // Start is called before the first frame update
    void Start()
    {
        GameObject torso = transform.GetChild(1).gameObject;
        torsoRB2d = torso.GetComponent<Rigidbody2D>();

        headRB2d = transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>();
        leftArmRB2d = transform.GetChild(2).gameObject.GetComponent<Rigidbody2D>();
        rightArmRB2d = transform.GetChild(3).gameObject.GetComponent<Rigidbody2D>();
        leftLegRB2d = transform.GetChild(4).gameObject.GetComponent<Rigidbody2D>();
        rightLegRB2d = transform.GetChild(5).gameObject.GetComponent<Rigidbody2D>();

        RM = GameObject.Find("RegionManager").GetComponent<RegionManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }

        if (RM != null)
        {
            if (RM.PlayerCurrentRegion == 5)
            {
                isInSpace = true;
            }
            else
            {
                isInSpace = false;
            }
        }


        if (isInSpace)
        {
            torsoRB2d.gravityScale = 0;
            headRB2d.gravityScale = 0;
            leftArmRB2d.gravityScale = 0;
            rightArmRB2d.gravityScale = 0;
            leftLegRB2d.gravityScale = 0;
            rightLegRB2d.gravityScale = 0;
        }
        else
        {
            torsoRB2d.gravityScale = 1;
            headRB2d.gravityScale = 1;
            leftArmRB2d.gravityScale = 1;
            rightArmRB2d.gravityScale = 1;
            leftLegRB2d.gravityScale = 1;
            rightLegRB2d.gravityScale = 1;
        }
    }

    public void Jump()
    {

        torsoRB2d.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
        //headRB2d.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
        Debug.Log("Jumping");
        canJump = false;
    }
}
