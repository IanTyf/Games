using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHit : MonoBehaviour
{

    public GameObject blood;
    public GameObject snowBallPop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if player hits the spike
        if (collision.tag == "Body")
        {
            GameObject bld = Instantiate(blood, collision.transform.position, Quaternion.identity);
            //Destroy(bld, 1.5f);

            GameObject RM = GameObject.Find("TrainingRestartManager");
            if (RM != null)
            {
                //RM.GetComponent<TrainingRestart>().ReloadScene();
                GameObject.Find("SceneFader").GetComponent<Animator>().SetTrigger("FadeOut");
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(6).GetComponent<RopeController>().ropeLock = true;
            }
        }

        // if snowball hits the spike
        if (collision.GetComponent<Snowball>() != null)
        {
            if (snowBallPop != null)
            {
                GameObject snowpop = Instantiate(snowBallPop, collision.transform.position, Quaternion.identity);
                //Destroy(snowpop, 1.5f);
            }

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            RopeController RC = player.transform.GetChild(6).GetComponent<RopeController>();

            if (RC.rope != null)
            {
                if (RC.rope.connectedBody != null)
                {
                    if (RC.rope.connectedBody == collision.GetComponent<Rigidbody2D>())
                    {
                        RC.rope = null;
                        Destroy(player.transform.GetChild(2).GetComponent<SpringJoint2D>());
                       
                    }
                }
            }

            if (RC.ropeTwo != null)
            {
                if (RC.ropeTwo.connectedBody != null)
                {
                    if (RC.ropeTwo.connectedBody == collision.GetComponent<Rigidbody2D>())
                    {
                        RC.ropeTwo = null;
                        Destroy(player.transform.GetChild(3).GetComponent<SpringJoint2D>());
                    }
                }
            }

            Destroy(collision.GetComponent<Rigidbody2D>());
            Destroy(collision.gameObject);
        }
    }
}
