using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject paintballSpawner;
    public GameObject StageManager;
    public GameObject InGameTimer;
    public GameObject MainMenu;


    public void StartGame()
    {
        paintballSpawner.SetActive(true);
        InGameTimer.SetActive(true);
        StageManager.GetComponent<StageManager>().CurrentStage = 0;
        StageManager.GetComponent<StageManager>().StartNewStage();
        MainMenu.SetActive(false);
    }
}
