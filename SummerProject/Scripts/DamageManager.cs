using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageManager : MonoBehaviour
{

    public GameObject DamageCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(GameObject from, GameObject to, float rawDamage)
    {
        float targetHP = to.GetComponent<Stats>().HP;


        if (targetHP > 0)
        {
            // if hitting an enemy, do whatever the enemy has for get hit (animation, sound, etc)
            if (to.tag == "Enemy")
            {
                to.GetComponent<Behaviors>().GetHit();
            }

            float targetDefense = to.GetComponent<Stats>().Defense;

            float Damage = rawDamage / targetDefense;
            Damage = (int)Damage;
            to.GetComponent<Stats>().HP -= Damage;

            // instantiate a damage number floating on the target
            Vector3 randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            GameObject DC = Instantiate(DamageCanvas, to.transform.position + randomOffset, Quaternion.identity);
            TextMeshProUGUI tm = DC.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            tm.text = "-" + Damage.ToString();
            Destroy(DC, 1.2f);

            if (to.GetComponent<Stats>().HP <= 0)
            {
                if (to.tag == "Enemy")   to.GetComponent<Behaviors>().Die();
                else if (to.tag == "Attached")
                {
                    InheritBody IB = to.GetComponentInParent<InheritBody>();
                    IB.inheritAnimation(to.transform.position);
                    Destroy(to.gameObject, 0.4f);
                    StartCoroutine(IB.backToGhost());
                    GameObject.Find("Player").tag = "Untagged";
                }
            }
        }
    }

}
