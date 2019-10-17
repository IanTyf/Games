using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public SpriteRenderer SR;
    public Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        defaultColor = SR.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlashColor(Color newColor)
    {
        SR.color = newColor;
        StartCoroutine(changeBackToDefalutColor());
    }

    IEnumerator changeBackToDefalutColor()
    {
        yield return new WaitForSeconds(0.15f);
        SR.color = defaultColor;
    }
}
