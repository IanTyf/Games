using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    public int score = -1;
    public Text scoreText;
    public float scoreHelper;

    public GameObject nextButton;
    public GameObject gameoverButton;
    public GameObject mainmenuButton;

    // Start is called before the first frame update
    void Start()
    {
        scoreHelper = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (score > 0)
        {
            scoreText.text = (scoreHelper).ToString("0");
            scoreHelper += (score/5f + 2) * Time.deltaTime;
            if (scoreHelper >= 80)
            {
                scoreText.color = new Color(86 / 255f, 1, 0);
            }
        }
        


        if (scoreHelper >= score && score != -1)
        {
            if (score >= 80)
            {
                nextButton.SetActive(true);
            }
            else
            {
                gameoverButton.SetActive(true);
            }
            mainmenuButton.SetActive(true);
            score = -1;
            scoreHelper = 0;
        }
    }

    public void NextStageButton()
    {
        GameObject.Find("StageManager").GetComponent<StageManager>().StartNewStage();
        Destroy(this.gameObject);
    }

    public void StartAgainButton()
    {
        GameObject.Find("StageManager").GetComponent<StageManager>().CurrentStage = 0;
        GameObject.Find("StageManager").GetComponent<StageManager>().StartNewStage();
        Destroy(this.gameObject);
    }

    public void GoToMainMenu()
    {
        GameObject.Find("paintballSpawner").SetActive(false);
        GameObject.Find("StageManager").GetComponent<StageManager>().CurrentStage = 0;
        GameObject.Find("InGame").SetActive(false);
        GameObject.Find("StageManager").GetComponent<StageManager>().showMainMenu();
        Destroy(this.gameObject);
    }
}
