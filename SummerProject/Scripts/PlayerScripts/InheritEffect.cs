using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritEffect : MonoBehaviour
{

    public Vector3 targetPos;

    private Vector3 goUpTo;
    private Vector3 goHorizontalTo;


    private bool goUp;
    private bool goHorizontal;
    private bool goDown;

    // Start is called before the first frame update
    void Start()
    {
        //after 0.4 seconds, start moving up to targetPos.y + 1
        goUp = false;
        goHorizontal = false;
        goDown = false;
        goUpTo = new Vector3(transform.position.x, targetPos.y + 1, 0);
        goHorizontalTo = new Vector3(targetPos.x, targetPos.y + 1, 0);
        StartCoroutine(enabler(0.4f));
    }

    // Update is called once per frame
    void Update()
    {
        if (goUp)
        {
            moveTowards(goUpTo, 2f);
            if (transform.position == goUpTo)
            {
                goUp = false;
                goHorizontal = true;
            }
        }
        else if (goHorizontal)
        {
            moveTowards(goHorizontalTo, 2f);
            if (transform.position == goHorizontalTo)
            {
                goHorizontal = false;
                goDown = true;
            }
        }
        else if (goDown)
        {
            moveTowards(targetPos, 3f);
            if (transform.position == targetPos)
            {
                goDown = false;
                GetComponent<Animator>().SetBool("isEnding", true);
                Destroy(this.gameObject, 1f);
            }
        }
    }

    private void moveTowards(Vector3 target, float speed)
    {
        
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        
    }

    IEnumerator enabler(float delay)
    {
        yield return new WaitForSeconds(delay);
        goUp = true;
    }
}
