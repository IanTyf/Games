using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePipe : MonoBehaviour
{


    public GameObject Snowball;

    public float spawnRate;

    private float timeSinceLastSpawn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > spawnRate)
        {
            GameObject SB = Instantiate(Snowball, transform.position, Quaternion.identity);
            float size = Random.Range(0.13f, 0.35f);
            SB.transform.localScale = new Vector3(size, size, size);
            timeSinceLastSpawn = 0;
        }

        
    }
}
