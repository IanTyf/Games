using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNextLevel()
    {
        // move player to 0,0
        GameObject player = GameObject.Find("Player");
        player.transform.position = Vector3.zero;
        PlayerMovement PM = player.GetComponent<PlayerMovement>();
        PM.CurrentRoomPosOnMatrix = new Vector2(2, 2);

        // reset camera to 0,0
        // Camera follows player according to the CurrentRoomPosOnMatrix, so it will get reset to 0,0 as the above code executes

        // destroy the children of canvas(minimap), rooms, monsters, items
        // 1st destroy everything on minimap canvas
        GameObject canvas = GameObject.Find("Canvas");
        foreach (Transform obj in canvas.transform)
        {
            Destroy(obj.gameObject);
        }
        // 2nd destroy every room
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
        foreach (GameObject obj in rooms)
        {
            Destroy(obj);
        }


        // regenerate rooms
        StartCoroutine(regenerateRoomAndMinimap());

    }

    IEnumerator regenerateRoomAndMinimap()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject RoomGenerator = GameObject.Find("RoomGenerator");
        RoomGenerator RG = RoomGenerator.GetComponent<RoomGenerator>();
        Debug.Log("Regenerating...");
        RG.ReGenerate();

        
    }
}
