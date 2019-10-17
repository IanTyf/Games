using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionManager : MonoBehaviour
{

    private GameObject player;

    public int PlayerCurrentRegion;

    [Header("Region1")]
    public Vector2 OneBL;
    public Vector2 OneBR;
    public Vector2 OneTL;
    public Vector2 OneTR;

    [Header("Region2")]
    public Vector2 TwoBL;
    public Vector2 TwoBR;
    public Vector2 TwoTL;
    public Vector2 TwoTR;

    [Header("Region3")]
    public Vector2 ThreeBL;
    public Vector2 ThreeBR;
    public Vector2 ThreeTL;
    public Vector2 ThreeTR;

    [Header("Region4")]
    public Vector2 FourBL;
    public Vector2 FourBR;
    public Vector2 FourTL;
    public Vector2 FourTR;

    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Torso");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Torso");
        }
        else
        {
            Vector2 pos = player.transform.position;

            if (pos.x < OneBL.x)
            {
                PlayerCurrentRegion = 4;
            }
            else if (pos.x > OneBR.x)
            {
                PlayerCurrentRegion = 2;
            }

            else if (pos.y > OneTL.y)
            {
                PlayerCurrentRegion = 5;
            }
            else if (pos.y < OneBL.y)
            {
                PlayerCurrentRegion = 3;
            }

            else
            {
                PlayerCurrentRegion = 1;
            }
        }



    }
}
