using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFireControl : MonoBehaviour
{

    //public float FireRate;

    //private float timeSinceLastFire;

    public Animator FireAnim;

    public Vector3 rotateTo;

    public float rotationSpeed;

    public GameObject bullet;

    public float minRange;
    public float maxRange;

    

    // Start is called before the first frame update
    void Start()
    {
        //timeSinceLastFire = 0;
        rotateTo = new Vector3(0, 0, 40);
    }

    // Update is called once per frame
    void Update()
    {

        transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, rotateTo, rotationSpeed * Time.deltaTime);
        if (Mathf.Abs(transform.localEulerAngles.z - rotateTo.z) < 0.5)
        {
            Fire();
            if (rotateTo.z > 20)
            {
                rotateTo = new Vector3(0, 0, Random.Range(0, 15));
            }
            else
            {
                rotateTo = new Vector3(0, 0, Random.Range(25, 40));
            }
        }




        
    }

    public void Fire()
    {
        FireAnim.SetBool("Fire", true);

        GameObject blt = Instantiate(bullet, transform.GetChild(0).position, Quaternion.identity);
        float z = rotateTo.z;
        float fireRange = Random.Range(minRange, maxRange);
        blt.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * z) * transform.parent.localScale.x, Mathf.Sin(Mathf.Deg2Rad * z)) * fireRange, ForceMode2D.Impulse);
        
    }

    public void resetTrigger()
    {
        FireAnim.SetBool("Fire", false);
    }




}
