using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRinDressingRoom : MonoBehaviour
{

    public LineRenderer LR;
    public LineRenderer LRTwo;

    public GameObject ropeShooterOne;
    public GameObject ropeShooterTwo;

    public bool isLeftRopeToggled;
    public bool isRightRopeToggled;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LR.SetPosition(0, ropeShooterOne.transform.position);
        LR.SetPosition(1, ropeShooterOne.GetComponent<SpringJoint2D>().connectedAnchor);

        LRTwo.SetPosition(0, ropeShooterTwo.transform.position);
        LRTwo.SetPosition(1, ropeShooterTwo.GetComponent<SpringJoint2D>().connectedAnchor);
    }

    public void SetLeftHandToggle(bool isToggled)
    {
        isLeftRopeToggled = isToggled;
    }

    public void SetRightHandToggle(bool isToggled)
    {
        isRightRopeToggled = isToggled;
    }


    public void ChangeLineColor(int rgb)
    {
        int r = 0;
        int g = 0;
        int b = 0;

        if (rgb >= 0)
        {
            r = rgb / 1000000;
            g = (rgb - r * 1000000) / 1000;
            b = rgb - r * 1000000 - g * 1000;
        }
        else
        {
            CustomButtonColor CBC = GameObject.Find("CustomColorButton").GetComponent<CustomButtonColor>();
            r = CBC.r;
            g = CBC.g;
            b = CBC.b;
        }


        if (isLeftRopeToggled)
        {
            LR.startColor = new Color(r/255f,g/255f,b/255f);
            LR.endColor = new Color(r/255f, g/255f, b/255f);
        }

        if (isRightRopeToggled)
        {
            LRTwo.startColor = new Color(r/255f, g/255f, b/255f);
            LRTwo.endColor = new Color(r/255f, g/255f, b/255f);
        }
    }



}
