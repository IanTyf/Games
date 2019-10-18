using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomGenerator : MonoBehaviour
{
    public float centerX;
    public float centerY;

    public int[,] matrix = new int[5, 5];

    public GameObject[] miniRooms;

    public GameObject[] Rooms;

    public GameObject[] miniRoomOnCanvas;

    public GameObject canvas;

    public bool isMinimapActive = false;



    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        isMinimapActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Generate();
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            matrix = new int[5, 5];
            SceneManager.LoadScene("Game");
        }
    }

    public void ReGenerate()
    {
        matrix = new int[5, 5];
        Generate();
    }

    public void Generate()
    {
        //first put a 4Open room in (3,3)
        matrix[2, 2] = 1111;
        //drawMiniRooms(2, 2, 1111);
        drawMiniRoomsOnCanvas(2, 2, 1111);
        drawRooms(2, 2, 1111);

        //call the recursive function with current position on matrix
        generate(2, 2);

        //pickBossRoom();
        drawInitialPlayerPosIndicator();
        isMinimapActive = true;

        // let the Room Manager Collect the rooms in its list
        RoomManager RM = GameObject.Find("RoomManager").GetComponent<RoomManager>();
        RM.RestoreListOfRooms();
    }

    private void generate(int x, int y)
    {
        // first retrieve current room doors
        int hasTop = hasDoor(matrix[x, y], "top");
        int hasRight = hasDoor(matrix[x, y], "right");
        int hasDown = hasDoor(matrix[x, y], "down");
        int hasLeft = hasDoor(matrix[x, y], "left");

        Debug.Log("pos:" + x + "," + y + "  " + hasTop + "," + hasRight + "," + hasDown + "," + hasLeft);

        // if current room has a top door
        if (hasTop == 1)
        {
            generateRoom(x - 1, y);
        }

        // if current room has a right door
        if (hasRight == 1)
        {
            generateRoom(x, y + 1);
        }

        // if current room has a down door
        if (hasDown == 1)
        {
            generateRoom(x + 1, y);
        }

        // if current room has a left door
        if (hasLeft == 1)
        {
            generateRoom(x, y - 1);
        }



    }

    private int hasDoor(int value, string direction)
    {
        int output = 0;
        switch (direction)
        {
            case "top":
                if (value / 1000 == 1) output = 1;
                break;
            case "right":
                if ((value / 100) % 10 == 1) output = 1;
                break;
            case "down":
                if ((value / 10) - (value / 100) * 10 == 1) output = 1;
                break;
            case "left":
                if ((value - (value / 10) * 10 == 1)) output = 1;
                break;

        }
        return output;


    }

    private bool checkAround(int x, int y, string direction)
    {
        int output = 0;
        switch (direction)
        {
            case "top":
                if (matrix[x - 1, y] != 0) output = 1;
                break;
            case "right":
                if (matrix[x, y + 1] != 0) output = 1;
                break;
            case "down":
                if (matrix[x + 1, y] != 0) output = 1;
                break;
            case "left":
                if (matrix[x, y - 1] != 0) output = 1;
                break;
        }
        return (output == 1);
    }

    private void generateRoom(int x, int y)
    {
        // if desired position has no room
        if (matrix[x, y] == 0)
        {

            // check if desired position has rooms around it.
            // if so, restrict the possibilities
            int[] roomNum = { -1, -1, -1, -1 };

            if (x == 0) roomNum[0] = 0;
            else if (checkAround(x, y, "top"))
            {
                roomNum[0] = hasDoor(matrix[x - 1, y], "down");
            }

            if (y == 4) roomNum[1] = 0;
            else if (checkAround(x, y, "right"))
            {
                roomNum[1] = hasDoor(matrix[x, y + 1], "left");
            }

            if (x == 4) roomNum[2] = 0;
            else if (checkAround(x, y, "down"))
            {
                roomNum[2] = hasDoor(matrix[x + 1, y], "top");
            }

            if (y == 0) roomNum[3] = 0;
            else if (checkAround(x, y, "left"))
            {
                roomNum[3] = hasDoor(matrix[x, y - 1], "right");
            }


            // randomly generate a room with restrictions
            System.Random random = new System.Random();
            for (int i = 0; i < roomNum.Length; i++)
            {
                if (roomNum[i] == -1)
                {
                    roomNum[i] = random.Next(0, 2);
                }
            }
            int roomVal = roomNum[0] * 1000 + roomNum[1] * 100 + roomNum[2] * 10 + roomNum[3];
            matrix[x, y] = roomVal;
            //drawMiniRooms(x, y, roomVal);
            drawMiniRoomsOnCanvas(x, y, roomVal);
            drawRooms(x, y, roomVal);
            generate(x, y);

        }
    }

    private void drawMiniRooms(int x, int y, int value)
    {
        float xpos = centerX + (y - 2) * 0.75f;
        float ypos = centerY - (x - 2) * 0.75f;

        switch (value)
        {
            case 1000:
                Instantiate(miniRooms[0], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0100:
                Instantiate(miniRooms[1], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0010:
                Instantiate(miniRooms[2], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0001:
                Instantiate(miniRooms[3], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1100:
                Instantiate(miniRooms[4], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0110:
                Instantiate(miniRooms[5], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0011:
                Instantiate(miniRooms[6], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1001:
                Instantiate(miniRooms[7], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1101:
                Instantiate(miniRooms[8], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1110:
                Instantiate(miniRooms[9], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0111:
                Instantiate(miniRooms[10], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1011:
                Instantiate(miniRooms[11], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1111:
                Instantiate(miniRooms[12], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1010:
                Instantiate(miniRooms[13], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0101:
                Instantiate(miniRooms[14], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
        }


    }

    private void pickBossRoom()
    {
        while (true)
        {
            System.Random rnd = new System.Random();
            int x = rnd.Next(0, 5);
            int y = rnd.Next(0, 5);
            float xpos = centerX + (y - 2) * 0.75f;
            float ypos = centerY - (x - 2) * 0.75f;
            if (matrix[x, y] != 0)
            {
                if (!(x == 2 && y == 2))
                {
                    Instantiate(miniRooms[15], new Vector3(xpos, ypos, 0), Quaternion.identity);
                    break;
                }
            }

        }
    }

    private void drawRooms(int x, int y, int value)
    {
        float xpos = (y - 2) * 21f;
        float ypos = -(x - 2) * 13f;

        switch (value)
        {
            case 1000:
                Instantiate(Rooms[0], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0100:
                Instantiate(Rooms[1], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0010:
                Instantiate(Rooms[2], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0001:
                Instantiate(Rooms[3], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1100:
                Instantiate(Rooms[4], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0110:
                Instantiate(Rooms[5], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0011:
                Instantiate(Rooms[6], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1001:
                Instantiate(Rooms[7], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1101:
                Instantiate(Rooms[8], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1110:
                Instantiate(Rooms[9], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0111:
                Instantiate(Rooms[10], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1011:
                Instantiate(Rooms[11], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1111:
                Instantiate(Rooms[12], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 1010:
                Instantiate(Rooms[13], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
            case 0101:
                Instantiate(Rooms[14], new Vector3(xpos, ypos, 0), Quaternion.identity);
                break;
        }
    }

    private void drawMiniRoomsOnCanvas(int x, int y, int value)
    {
        float xpos = centerX + (y - 2) * 0.5f;
        float ypos = centerY - (x - 2) * 0.5f;

        switch (value)
        {
            case 1000:
                Instantiate(miniRoomOnCanvas[0], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 0100:
                Instantiate(miniRoomOnCanvas[1], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 0010:
                Instantiate(miniRoomOnCanvas[2], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 0001:
                Instantiate(miniRoomOnCanvas[3], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 1100:
                Instantiate(miniRoomOnCanvas[4], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 0110:
                Instantiate(miniRoomOnCanvas[5], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 0011:
                Instantiate(miniRoomOnCanvas[6], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 1001:
                Instantiate(miniRoomOnCanvas[7], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 1101:
                Instantiate(miniRoomOnCanvas[8], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 1110:
                Instantiate(miniRoomOnCanvas[9], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 0111:
                Instantiate(miniRoomOnCanvas[10], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 1011:
                Instantiate(miniRoomOnCanvas[11], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 1111:
                Instantiate(miniRoomOnCanvas[12], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 1010:
                Instantiate(miniRoomOnCanvas[13], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
            case 0101:
                Instantiate(miniRoomOnCanvas[14], new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);
                break;
                
        }
    }

    private void drawInitialPlayerPosIndicator()
    {
        Instantiate(miniRoomOnCanvas[15], new Vector3(centerX, centerY, 0), Quaternion.identity, canvas.transform);
    }

    
}
