using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButtonColor : MonoBehaviour
{

    public Button button;
    public Text rInput;
    public Text gInput;
    public Text bInput;

    public int r;
    public int g;
    public int b;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rInput.text != "")
        {
            r = int.Parse(rInput.text);
        }
        else
        {
            r = 0;
        }

        if (gInput.text != "")
        {
            g = int.Parse(gInput.text);
        }
        else
        {
            g = 0;
        }

        if (bInput.text != "")
        {
            b = int.Parse(bInput.text);
        }
        else
        {
            b = 0;
        }

        ColorBlock col = button.colors;
        col.normalColor = new Color(r/255f, g/255f, b/255f);
        col.highlightedColor = new Color(r/255f, g/255f, b/255f);
        button.colors = col;
    }
}
