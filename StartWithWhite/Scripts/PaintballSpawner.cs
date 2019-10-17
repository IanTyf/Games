using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballSpawner : MonoBehaviour
{

    public GameObject paintball;
    public bool shouldSpawn;

    private float spawnBetweenSeconds;
    private float timeSinceLastSpawn;

    public float spawnGapMin;
    public float spawnGapMax;

    public float pbMinSize;
    public float pbMaxSize;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = 0;
        spawnBetweenSeconds = Random.Range(spawnGapMin, spawnGapMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSpawn)
        {
            if (timeSinceLastSpawn >= spawnBetweenSeconds)
            {
                spawnAtRandomPlace();
                timeSinceLastSpawn = 0;
                spawnBetweenSeconds = Random.Range(spawnGapMin, spawnGapMax);
            }
            else
            {
                timeSinceLastSpawn += Time.deltaTime;
            }
        }
    }

    private void spawnAtRandomPlace()
    {
        Vector2 startPos = getRandomPos();
        Vector2 target = getRandomPos();
        float randomSize = Random.Range(pbMinSize, pbMaxSize);

        GameObject pb = Instantiate(paintball, startPos, Quaternion.identity);
        pb.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 256)/255f, Random.Range(0, 256)/255f, Random.Range(0, 256)/255f);
        pb.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
        pb.GetComponent<paintballMovement>().target = target;
        pb.GetComponent<paintballMovement>().speed = Random.Range(4f, 6f);
        
    }

    private Vector2 getRandomPos()
    {
        Vector2 randomPos = new Vector2(Random.Range(-10f, 10f), Random.Range(-6f, 6f));
        int rnd = Random.Range(0, 4);
        switch (rnd)
        {
            case 0:
                randomPos.x = -10;
                break;
            case 1:
                randomPos.x = 10;
                break;
            case 2:
                randomPos.y = 6;
                break;
            case 3:
                randomPos.y = -6;
                break;
        }
        return randomPos;
    }

}
