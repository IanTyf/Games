using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEvent : MonoBehaviour
{
    public GameObject chatbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        chatbox.SetActive(true);
    }

    private void OnMouseExit()
    {
        chatbox.SetActive(false);
    }
}
