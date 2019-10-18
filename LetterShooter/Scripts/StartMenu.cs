using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{

    public GameObject player;
    public GameObject startIcon;

    public void Start()
    {
        Time.timeScale = 0;
    }

    
    public void OnMouseDown()
    {
        Debug.Log("Hit Start");
        player.SetActive(true);
        startIcon.SetActive(false);
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
