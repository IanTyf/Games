using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public GameObject TA;
    public GameObject QT;

    

    public void restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }

        ScoreBoard SB = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>();
        SB.resetScore();

        TA.SetActive(false);
        QT.SetActive(false);

        Time.timeScale = 1;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void showMenu()
    {
        Debug.Log("Aha");
        Time.timeScale = 0;
        TA.SetActive(true);
        QT.SetActive(true);
    }
}
