using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    
    public Text easyText;
    public Text mediumText;
    public Text hardText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void highlightEasy()
    {
        easyText.color = Color.green;
        mediumText.color = Color.black;
        hardText.color = Color.black;
    }

    public void highlightMedium()
    {
        easyText.color = Color.black;
        mediumText.color = Color.green;
        hardText.color = Color.black;
    }

    public void highlightHard()
    {
        easyText.color = Color.black;
        mediumText.color = Color.black;
        hardText.color = Color.green;
    }
}
