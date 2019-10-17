using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameTimer : MonoBehaviour
{
    public float InGameCountDown;
    public Text InGameCountDownText;

    public bool shouldStartTimer;

    public GameObject StageManager;

    // Start is called before the first frame update
    void Start()
    {
        InGameCountDown = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldStartTimer)
        {
            InGameCountDown -= Time.deltaTime;
            if (InGameCountDown <= -0.5f)
            {
                StageManager.GetComponent<StageManager>().PlayerFinishColor = GameObject.Find("Player").GetComponent<SpriteRenderer>().color;
                StageManager.GetComponent<StageManager>().LoadResultScreen();
                shouldStartTimer = false;
            }
            else
            {
                InGameCountDownText.text = (InGameCountDown).ToString("0");
            }
        }
    }

    public void StartTimer()
    {
        if (!shouldStartTimer)
        {
            InGameCountDown = 30;
            shouldStartTimer = true;
        }
    }


}
