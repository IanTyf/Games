using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDehydration : MonoBehaviour
{
    public GameObject Sweat;

    public bool isDehydrating;

    public bool isInWater;

    public GameObject RM;

    public float DehydrationTimer;

    public float DieAfterSeconds;

    

    // Start is called before the first frame update
    void Start()
    {
        //isDehydrating = false;
        isInWater = false;
        RM = GameObject.Find("RegionManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (RM != null)
        {
            isDehydrating = (RM.GetComponent<RegionManager>().PlayerCurrentRegion == 4);
            
        }

        if (isDehydrating && !isInWater)
        {
            DehydrationTimer += Time.deltaTime;
            
            if (DehydrationTimer >= (DieAfterSeconds/3))
            {
                if (DehydrationTimer < (DieAfterSeconds * 2 / 3))
                {
                    Sweat.SetActive(true);
                }
                else if (DehydrationTimer < DieAfterSeconds)
                {
                    ParticleSystem PS = Sweat.GetComponent<ParticleSystem>();
                    ParticleSystem.MainModule main = PS.main;
                    ParticleSystem.EmissionModule Emain = PS.emission;
                    main.startSize = 0.15f;
                    main.startSpeed = 3.5f;
                    main.startLifetime = 0.8f;
                    Emain.rateOverTime = 8f;
                }
                else
                {
                    
                }
            }
            else
            {
                //DehydrationTimer = 0;
                ParticleSystem PS = Sweat.GetComponent<ParticleSystem>();
                ParticleSystem.MainModule main = PS.main;
                ParticleSystem.EmissionModule Emain = PS.emission;
                main.startSize = 0.1f;
                main.startSpeed = 2f;
                main.startLifetime = 0.5f;
                Emain.rateOverTime = 4f;
                Sweat.SetActive(false);
            }
            

            for (int i=0; i<6; i++)
            {
                GameObject bodyPart = transform.GetChild(i).gameObject;
                SpriteRenderer SR = bodyPart.GetComponent<SpriteRenderer>();
                Color oldColor = SR.color;
                bodyPart.GetComponent<SpriteRenderer>().color = new Color(oldColor.r, oldColor.g, oldColor.b, Mathf.Max((DieAfterSeconds * 2 - DehydrationTimer) / (DieAfterSeconds*2), 0.5f));
            }


        }
        else
        {
            DehydrationTimer = 0;
            ParticleSystem PS = Sweat.GetComponent<ParticleSystem>();
            ParticleSystem.MainModule main = PS.main;
            ParticleSystem.EmissionModule Emain = PS.emission;
            main.startSize = 0.1f;
            main.startSpeed = 2f;
            main.startLifetime = 0.5f;
            Emain.rateOverTime = 4f;
            Sweat.SetActive(false);

            for (int i = 0; i < 6; i++)
            {
                GameObject bodyPart = transform.GetChild(i).gameObject;
                SpriteRenderer SR = bodyPart.GetComponent<SpriteRenderer>();
                Color oldColor = SR.color;
                bodyPart.GetComponent<SpriteRenderer>().color = new Color(oldColor.r, oldColor.g, oldColor.b, 1f);
            }
        }

    }
}
