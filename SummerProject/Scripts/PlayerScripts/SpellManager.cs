using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    public Spells spell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(spell.castFirstSpell())
            {
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                StartCoroutine(ReEnableMovement(spell.getFirstSpellLength()));
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if(spell.castSecondSpell())
            {
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                StartCoroutine(ReEnableMovement(spell.getSecondSpellLength()));
            }
        }
    }

    IEnumerator ReEnableMovement(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<PlayerMovement>().enabled = true;

    }
}
