using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public int direction;

    public float spawnSpeed;

    public float spawnRate;

    public float spawnGap;

    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        spawnGap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (spawnGap >= spawnRate)
        {
            int random = Random.Range(0, enemies.Length);
            GameObject enemy = Instantiate(enemies[random], transform.position, Quaternion.identity);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.speed = this.spawnSpeed;
            enemyScript.direction = this.direction;
            spawnGap = 0;
        }
        else
        {
            spawnGap += Time.deltaTime;
        }
    }

    public void setSpawnRateLR(Slider slider)
    {
        spawnRate = (1-slider.value) + 0.3f;
    }

    public void setSpawnSpeedLR(Slider slider)
    {
        spawnSpeed = slider.value * 2f + 0.6f;
    }

    public void setSpawnRateUD(Slider slider)
    {
        spawnRate = (1-slider.value) * 4f + 1f;
    }

    public void setSpawnSpeedUD(Slider slider)
    {
        spawnSpeed = slider.value + 0.5f;
    }

    public void easyMode()
    {
        if (direction % 2 == 0)
        {
            spawnSpeed = 0.8f;
            spawnRate = 1.6f;
        }
        else
        {
            spawnSpeed = 0.5f;
            spawnRate = 4f;
        }
    }

    public void mediumMode()
    {
        if (direction % 2 == 0)
        {
            spawnSpeed = 1.6f;
            spawnRate = 0.8f;
        }
        else
        {
            spawnSpeed = 1f;
            spawnRate = 3f;
        }
    }

    public void hardMode()
    {
        if (direction % 2 == 0)
        {
            spawnSpeed = 2.4f;
            spawnRate = 0.6f;
        }
        else
        {
            spawnSpeed = 1.5f;
            spawnRate = 2f;
        }
    }
}
