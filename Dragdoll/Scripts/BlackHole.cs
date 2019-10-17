using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    public float AffectRange;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rotate();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        
        if (Vector2.Distance(player.transform.GetChild(1).transform.position, transform.position) < AffectRange)
            {
                pull();
                Debug.Log(name);
            }
        
    }

    private void rotate()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward + transform.rotation.eulerAngles);
    }

    private void pull()
    {
        player.transform.GetChild(1).GetComponent<Rigidbody2D>().AddForce(6*(transform.position - player.transform.GetChild(1).transform.position).normalized);
        //Debug.Log(name);
    }
}
