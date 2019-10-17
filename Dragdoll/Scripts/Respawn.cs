using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public Vector3 respawnPos;
    public GameObject Ragdoll;

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
            Destroy(collision.transform.parent.gameObject);
            StartCoroutine(spawn());
        }
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 0)
        {
            Instantiate(Ragdoll, respawnPos, Quaternion.identity);
        }
    }

}
