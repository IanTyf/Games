using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritBody : MonoBehaviour
{

    public GameObject checkPoint;

    public GameObject defaultGhost;

    public bool CanInherit;

    public GameObject inheritEffect;

    // Start is called before the first frame update
    void Start()
    {
        CanInherit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && CanInherit == true)
        {
            Inherit();
            CanInherit = false;
            this.tag = "Untagged";
        }


    }

    public void Inherit()
    {
        PlayerMovement PM = GetComponent<PlayerMovement>();
        GameObject checkPt = Instantiate(checkPoint, transform.position + Vector3.right * PM.facing * 1f, Quaternion.identity);
        CheckPoint CP = checkPt.GetComponent<CheckPoint>();
        StartCoroutine(actualInherit(CP, checkPt));
        Destroy(checkPt, 0.3f);
        
    }

    IEnumerator actualInherit(CheckPoint CP, GameObject checkPoint)
    {
        yield return new WaitForSeconds(0.2f);
        if (CP.collidedWith == "Dead")
        {

            if (transform.childCount >= 1)
            {
                Destroy(transform.GetChild(0).gameObject, 0.4f);

            }
            

            Debug.Log("Inheriting...");
            GameObject deadBody = CP.collidedObj;
            DeadBody DB = deadBody.GetComponent<DeadBody>();

            Vector3 deadBodyPos = deadBody.transform.position;
            Vector3 deadBodyCenter = deadBodyPos + DB.pivotOffset;
            StartCoroutine(movePlayerPos(deadBodyPos));

            inheritAnimation(deadBodyCenter);
            
            StartCoroutine(actuallyInstantiateAndInherit(DB));


            //deadBody.transform.SetParent(transform);
            //deadBody.transform.localPosition = Vector3.zero;
            //deadBody.tag = "Attached";
        }
        else
        {
            inheritAnimation(transform.position);
            Destroy(transform.GetChild(0).gameObject, 0.4f);
            StartCoroutine(backToGhost());
        }
        Destroy(checkPoint);
    }

    public IEnumerator backToGhost()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(defaultGhost, transform);
        GetComponent<PlayerMovement>().moveSpeed = GetComponent<PlayerMovement>().defaultMoveSpeed;
        CanInherit = true;
        this.tag = "Player";
        
    }

    IEnumerator movePlayerPos(Vector2 pos)
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = pos;
    }

    IEnumerator actuallyInstantiateAndInherit(DeadBody DB)
    {
        yield return new WaitForSeconds(2.8f);
        GameObject child = DB.getAlive();
        //GSGOnPlayerMovement GSGOPM = child.GetComponent<GSGOnPlayerMovement>();
        //this.GetComponent<PlayerMovement>().moveSpeed = GSGOPM.speed;

        OnPlayerMovement OPM = child.GetComponent<OnPlayerMovement>();
        this.GetComponent<PlayerMovement>().moveSpeed = OPM.getSpeed() + 2;

        this.GetComponent<SpellManager>().spell = child.GetComponent<Spells>();
        CanInherit = true;
        this.tag = "Player";
        
    }



    // instantiate startInherit effect
    // find target position
    // give startInherit effect value to move
    // after the effect grows big, destroy child  and move player position to dead body position
    public void inheritAnimation(Vector3 targetPos)
    {
        GameObject inhEfct = Instantiate(inheritEffect, transform.position, Quaternion.identity);
        inhEfct.GetComponent<InheritEffect>().targetPos = targetPos;
    }
}
