using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public GameObject BreakEffect;

    // 0 for no hit, 1 for 1 hit, 2 for 2 hits, and when >2 it breaks
    public int currentBreakStage;




    public void Break()
    {
        if (currentBreakStage < 2)
        {
            currentBreakStage++;
            showNextBreakStage(currentBreakStage);
        }
        else
        {
            
            RopeController RC = GameObject.FindGameObjectWithTag("Player").transform.GetChild(6).GetComponent<RopeController>();

            if (RC.rope != null)
            {
                if (RC.rope.connectedBody != null)
                {
                    if (RC.rope.connectedBody == GetComponent<Rigidbody2D>()) RC.rope = null;
                }
            }

            if (RC.ropeTwo != null)
            {
                if (RC.ropeTwo.connectedBody != null)
                {
                    if (RC.ropeTwo.connectedBody == GetComponent<Rigidbody2D>()) RC.ropeTwo = null;
                }
            }

            Instantiate(BreakEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void showNextBreakStage(int nextStage)
    {
        transform.GetChild(nextStage - 1).gameObject.SetActive(true);
    }

}
