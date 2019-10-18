using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWSpells : MonoBehaviour, Spells
{
    public Animator anim;

    public bool hasAxe;

    public bool firstSpellLock;
    public bool secondSpellLock;

    public float firstSpellLength;
    public float secondSpellLength;

    public Coroutine releaseAxeCo;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        hasAxe = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool castFirstSpell()
    {
        if (!anim.GetBool("isThrowingAxe") && !anim.GetBool("isSwingingHammer"))
        {
            anim.SetBool("isSwingingHammer", true);

            transform.GetChild(2).GetChild(0).GetComponent<BoxCollider2D>().enabled = true;

            StartCoroutine(disableCollider());

            StartCoroutine(finishSwinging());

            return firstSpellLock;
        }
        else
        {
            return false;
        }
    }

    public bool castSecondSpell()
    {
        if (hasAxe && anim.GetBool("isSwingingHammer")== false)
        {
            Debug.Log("Throwing Axe!");

            hasAxe = false;

            if (transform.localScale.x > 0)
            {
                anim.SetBool("isThrowingAxe", true);
            }
            else
            {
                anim.SetBool("isThrowingAxeLeft", true);
            }

            releaseAxeCo = StartCoroutine(releaseAxe());

            StartCoroutine(finishThrowing());

            return secondSpellLock;
        }
        else
        {
            return false;
        }
    }

    public float getFirstSpellLength()
    {
        return firstSpellLength;
    }

    public float getSecondSpellLength()
    {
        return secondSpellLength;
    }

    IEnumerator disableCollider()
    {
        yield return new WaitForSeconds(0.3f);
        transform.GetChild(2).GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator finishSwinging()
    {
        yield return new WaitForSeconds(0.6f);
        anim.SetBool("isSwingingHammer", false);
        
    }

    IEnumerator finishThrowing()
    {
        yield return new WaitForSeconds(1f);
        if (anim.GetBool("isThrowingAxe"))
            anim.SetBool("isThrowingAxe", false);
        else if (anim.GetBool("isThrowingAxeLeft")) anim.SetBool("isThrowingAxeLeft", false);
    }

    IEnumerator releaseAxe()
    {
        yield return new WaitForSeconds(0.6f);
        GameObject axe = transform.GetChild(1).GetChild(0).gameObject;
        axe.transform.SetParent(null, true);
        AxeMovement AM = axe.GetComponent<AxeMovement>();
        if (transform.localScale.x > 0) AM.direction = 1;
        else AM.direction = -1;
        AM.activateCollider();
        AM.thrown = true;
        AM.targetPos = new Vector2(axe.transform.position.x + AM.maxDistance * AM.direction, axe.transform.position.y);
        releaseAxeCo = null;
    }
}
