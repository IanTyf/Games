using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public BehaviorControl BC;

    public GameObject bullet;

    public float timeSinceStartShooting;

    public float timeSinceCD;

    public float timeSinceLastBullet;

    public bool isActuallyShooting;


    // Start is called before the first frame update
    void Start()
    {
        BC = gameObject.GetComponent<BehaviorControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BC.isShooting)
        {
            if (timeSinceStartShooting < BC.keepShootingSeconds)
            {
                isActuallyShooting = true;
                Shoot();
                timeSinceStartShooting += Time.deltaTime;
            }

            else if (timeSinceCD < BC.shootingCD)
            {
                isActuallyShooting = false;
                timeSinceCD += Time.deltaTime;
            }

            else
            {
                timeSinceStartShooting = 0;
                timeSinceCD = 0;
                timeSinceLastBullet = 0;
            }
        }
        else
        {
            timeSinceStartShooting = 0;
            timeSinceCD = 0;
            timeSinceLastBullet = 0;
        }
    }

    private void shoot()
    {
        if (timeSinceLastBullet == 0)
        {
            // instantiate
            GameObject blt = Instantiate(bullet, transform.position + Vector3.right * BC.facing, Quaternion.identity);
            blt.GetComponent<Bullets>().speed *= BC.facing;
        }

        timeSinceLastBullet += Time.deltaTime;

        if (timeSinceLastBullet > BC.shotGap)
        {
            timeSinceLastBullet = 0;
        }

        
    }

    private void Shoot()
    {
        if (timeSinceLastBullet > BC.shotGap)
        {
            GameObject blt = Instantiate(bullet, transform.position + Vector3.right * BC.facing, Quaternion.identity);
            blt.GetComponent<Bullets>().speed *= BC.facing;
            timeSinceLastBullet = 0;
        }

        timeSinceLastBullet += Time.deltaTime;
    }
}
