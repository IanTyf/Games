using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSGOnPlayerMovement : MonoBehaviour, OnPlayerMovement
{

    public float speed;

    public Vector3 oldPos;

    public Animator anim;

    private PlayerMovement PM;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PM = transform.parent.gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PM.isMoving)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            StartCoroutine(TurnAroundDelay());
        
        }

        

        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * PM.facing, transform.localScale.y, transform.localScale.z);


    }

    public float getSpeed()
    {
        return speed;
    }

    void hey()
    {
        if (transform.position != oldPos)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);

        }

        oldPos = transform.position;
    }

    IEnumerator TurnAroundDelay()
    {
        yield return new WaitForSeconds(0.02f);
        if (PM.isMoving == false) anim.SetBool("isWalking", false);
    }

    
}
