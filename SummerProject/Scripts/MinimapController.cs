using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public GameObject playerIndicatorOnMiniMap;

    public GameObject player;

    public GameObject RG;

    public GameObject canvas;

    public Vector2 playerMatrixPosComparator;

    public bool isMinimapActive = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        RG = GameObject.Find("RoomGenerator");
        canvas = GameObject.Find("Canvas");
        playerMatrixPosComparator = new Vector2(2, 2);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        updateMinimapState();
        if (isMinimapActive)
        {
            PlayerMovement pM = player.GetComponent<PlayerMovement>();
            if (playerMatrixPosComparator.x != pM.CurrentRoomPosOnMatrix.x || playerMatrixPosComparator.y != pM.CurrentRoomPosOnMatrix.y)
            {
                updatePlayerPosOnMinimap();
            }
        }
    }

    private void updatePlayerPosOnMinimap()
    {
        RoomGenerator RGScript = RG.GetComponent<RoomGenerator>();
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        GameObject[] currentIndicators = GameObject.FindGameObjectsWithTag("CurrentPosIndicator");
        foreach (GameObject obje in currentIndicators)
        {
            Destroy(obje);
        }

        // ******************************** IMPORTANT UI-CAMERA FOLLOW OFFSET VALUE RIGHT HERE. With example below.
        // + (pm.CurrentRoomPosOnMatrix.y - 2) * 21f;
        // - (pm.CurrentRoomPosOnMatrix.x - 2) * 13f;
        // this offset is needed because it seems that the camera's position is not updated when this is called in the same frame.
        // if making the following code in a coroutine, the offset won't be needed.
        float xcenter = RGScript.centerX + (pm.CurrentRoomPosOnMatrix.y - 2) * 21f ;
        float ycenter = RGScript.centerY - (pm.CurrentRoomPosOnMatrix.x - 2) * 13f;
        float xpos = xcenter + (pm.CurrentRoomPosOnMatrix.y - 2) * 0.5f;
        float ypos = ycenter - (pm.CurrentRoomPosOnMatrix.x - 2) * 0.5f;
        Debug.Log("heyhey" + xpos + "," + ypos);
        GameObject obj = Instantiate(playerIndicatorOnMiniMap, new Vector3(xpos, ypos, 0), Quaternion.identity, canvas.transform);

        playerMatrixPosComparator = pm.CurrentRoomPosOnMatrix;
        
    }

    private void updateMinimapState()
    {
        this.isMinimapActive = RG.GetComponent<RoomGenerator>().isMinimapActive;
    }

    
}
