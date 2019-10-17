using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timeSinceStarted;
    public float startTime;

    public bool isStopped;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopped)
        {

            timeSinceStarted = Time.time - startTime;

            int minute = ((int)timeSinceStarted / 60);
            float seconds = (timeSinceStarted % 60);

            if (seconds < 10)
            {
                timerText.text = minute.ToString("D2") + ":0" + seconds.ToString("f2");
            }
            else
            {
                timerText.text = minute.ToString("D2") + ":" + seconds.ToString("f2");
            }
        }
    }

    /*
     * if (minute == 0f)
        {
            if (seconds < 10)
            {
                timerText.text = "00:0" + seconds.ToString("f2");
            }
            else
            {
                timerText.text = "00:" + seconds.ToString("f2");
            }
        }
        else
        {
            if (seconds < 10)
            {
                timerText.text = minute.ToString() + ":0" + seconds.ToString("f2");
            }
            else
            {
                timerText.text = minute + ":" + seconds; ;
            }
        }
        */
}
