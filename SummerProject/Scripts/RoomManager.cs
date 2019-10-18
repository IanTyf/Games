using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this room manager holds all the rooms currently in the scene and takes care of putting stuff in a specific room
public class RoomManager : MonoBehaviour
{

    public float chanceOfEnemyRoom;

    public List<GameObject> rooms = new List<GameObject>();

    public string[] roomType;

    public GameObject ladder;

    private int ladderRoomNum;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestoreListOfRooms()
    {
        rooms = new List<GameObject>();
        GameObject[] rms = GameObject.FindGameObjectsWithTag("Room");
        foreach (GameObject obj in rms)
        {
            rooms.Add(obj);
        }

        generateLadderInOneRoom();

        roomType = new string[rooms.Count];
        determineRoomTypes();

        generateEnemies();
    }

    public void generateLadderInOneRoom()
    {
        System.Random rnd = new System.Random();
        int roomNum = rnd.Next(1, rooms.Count);
        GameObject lad = Instantiate(ladder, rooms[roomNum].transform);
        ladderRoomNum = roomNum;
        
    }

    /**
     * Generates enemies in all selected enemy rooms
     */ 
    public void generateEnemies()
    {
        EnemyGenerator EG = GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>();
        for (int i=0; i<roomType.Length; i++)
        {
            if (roomType[i] == "E")
            {
                
                EG.generateARoomOfEnemies(rooms[i]);
            }
        }
        
        
    }
    
    /**
     * For each newly created rooms, give it a alphabet representing its room type
     * E for enemy room
     */
    public void determineRoomTypes()
    {
        for (int i=1; i<roomType.Length; i++)
        {
            if (i != ladderRoomNum)
            {
                float rnd = Random.Range(0f, 1f);
                if (rnd < chanceOfEnemyRoom)
                {
                    roomType[i] = "E";
                }
            }
        }
    }
}
