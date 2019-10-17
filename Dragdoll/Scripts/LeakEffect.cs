using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakEffect : MonoBehaviour
{
    public string whichHand;

    public ParticleSystem particle;

    public GameObject theSand;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public void End()
    {
        //particle.Stop();
        Destroy(this.gameObject);
        if (whichHand == "left") theSand.GetComponent<SandBehavior>().isLeftHandLeaking = false;
        else if (whichHand == "right") theSand.GetComponent<SandBehavior>().isRightHandLeaking = false;
    }

    
}
