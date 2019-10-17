using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{

    public int CurrentStage;
    public float StartStageCountDown;

    public Color GoalColor;
    public Color PlayerFinishColor;

    public Text CountDownText;
    public Text InGameCountDownText;

    public GameObject StartStageMenu;
    public GameObject Player;
    public GameObject InGameTimer;
    public GameObject EndOfScreen;
    public GameObject Mainmenu;

    public bool isStartMenu;

    // Start is called before the first frame update
    void Start()
    {
        CurrentStage = 0;
        StartStageCountDown = 10f;
        //StartNewStage();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartMenu)
        {
            StartMenuCountDown();
        }

        
    }

    public void StartMenuCountDown()
    {
        StartStageCountDown -= Time.deltaTime;
        if (StartStageCountDown <= 0.5f)
        {
            CountDownText.text = "color!";
        }
        else
        {

            CountDownText.text = (StartStageCountDown).ToString("0");
        }

        if (StartStageCountDown < -1)
        {
            StartStage();
            isStartMenu = false;
        }
    }

    public void StartStage()
    {
        StartStageMenu.SetActive(false);
        Player.transform.position = Vector3.zero;
        Player.SetActive(true);
        //InGameCountDown = 60;
        InGameTimer.GetComponent<InGameTimer>().StartTimer();
    }

    

    public void LoadResultScreen()
    {
        Player.SetActive(false);
        GameObject EndStageMenu = Instantiate(EndOfScreen, Vector3.zero, Quaternion.identity);
        EndStageMenu.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Player.GetComponent<SpriteRenderer>().color;
        EndStageMenu.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = GoalColor;
        EndStageMenu.GetComponent<ScoreDisplay>().score = calculateScore(PlayerFinishColor, GoalColor);
    }

    public void StartNewStage()
    {
        
        CurrentStage++;
        StartStageCountDown = 10 - CurrentStage;
        if (StartStageCountDown <= 3)
        {
            StartStageCountDown = 3;
        }
        Player.GetComponent<SpriteRenderer>().color = Color.white;
        GoalColor = new Color(Random.Range(0, 256) / 255f, Random.Range(0, 256) / 255f, Random.Range(0, 256) / 255f);
        GameObject goalsquare = StartStageMenu.transform.GetChild(1).gameObject;
        goalsquare.GetComponent<SpriteRenderer>().color = GoalColor;
        StartStageMenu.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>().text = "LEVEL " + CurrentStage;
        isStartMenu = true;
        StartStageMenu.SetActive(true);
    }

    public int calculateScore(Color playercol, Color goalCol)
    {
        float colordiff = Mathf.Pow((playercol.r - goalCol.r) * (playercol.r - goalCol.r)*255*255 + (playercol.g - goalCol.g) * (playercol.g - goalCol.g)*255*255
            + (playercol.b - goalCol.b) * (playercol.b - goalCol.b)*255*255, 0.5f);
        Debug.Log("colordiff is " + colordiff);
        int score = (int)((100 - colordiff / 5.5f)*4/5 + 20);
        Debug.Log("score is " + score);
        return score;
    }

    public void showMainMenu()
    {
        Mainmenu.SetActive(true);
    }
}
