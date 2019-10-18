using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    public int currentScore;

    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementScore()
    {
        currentScore++;
        ScoreText.text = "Score: " + currentScore;
    }

    public void resetScore()
    {
        currentScore = 0;
        ScoreText.text = "Score: 0";
    }

}
