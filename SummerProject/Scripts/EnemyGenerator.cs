using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public int minNumOfEnemiesInOneRoom;
    public int maxNumOfEnemiesInOneRoom;
    public float spawnRadius;

    public GameObject[] WeakEnemies;
    public GameObject[] NormalEnemies;
    public GameObject[] StrongEnemies;

    public GameObject[] Bosses;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Given a room, generate a room of enemies
     */
    public void generateARoomOfEnemies(GameObject room)
    {
        // firstly, decide how many enemies are in this room (2-4)
        int numOfEnemies = Random.Range(minNumOfEnemiesInOneRoom, maxNumOfEnemiesInOneRoom+1);

        // secondly, randomly generate "numOfEnemies" number of positions
        Vector3[] positions = getRandomVec3(numOfEnemies);

        // thirdly, for each position, randomly select a enemy in weakEnemies to spawn at that position
        foreach (Vector3 pos in positions)
        {
            int randomIndex = Random.Range(0, WeakEnemies.Length);
            GameObject enm = Instantiate(WeakEnemies[randomIndex], room.transform, false);
            enm.transform.localPosition = pos;
        }
    }

    private Vector3[] getRandomVec3(int numOfPos)
    {
        int counter = 0;
        Vector3[] output = new Vector3[numOfPos];

        while (counter < numOfPos)
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-2.5f, 2.5f);
            float z = 0;
            Vector3 candidatePos = new Vector3(x, y, z);

            if (counter-1 >= 0)
            {
                bool isValid = true;
                for (int i = 0; i < counter; i++)
                {
                    float dist = Vector3.Distance(candidatePos, output[i]);
                    if (dist < spawnRadius)
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    output[counter] = candidatePos;
                    counter++;
                }
                
            }
            else
            {
                output[counter] = candidatePos;
                counter++;
            }
        }

        return output;
    }

}
