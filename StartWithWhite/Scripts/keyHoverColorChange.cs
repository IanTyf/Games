using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyHoverColorChange : MonoBehaviour
{

    public SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        SR.color = Color.gray;
    }

    private void OnMouseExit()
    {
        SR.color = Color.white;
    }
}
