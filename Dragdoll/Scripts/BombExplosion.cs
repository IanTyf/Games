using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{

    public GameObject BloodEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Body")
        {
            Instantiate(BloodEffect, collision.transform.position, Quaternion.identity);

            GameObject RM = GameObject.Find("TrainingRestartManager");
            if (RM != null)
            {
                //RM.GetComponent<TrainingRestart>().ReloadScene();
                GameObject.Find("SceneFader").GetComponent<Animator>().SetTrigger("FadeOut");
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(6).GetComponent<RopeController>().ropeLock = true;
            }
        }

        if (collision.GetComponent<Stone>() != null)
        {
            if (collision.isTrigger == false)
            {
                collision.GetComponent<Stone>().Break();
            }

        }
    }

}
