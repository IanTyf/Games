using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWOnPlayerMovement : MonoBehaviour, OnPlayerMovement
{

    public float speed;

    public Animator anim;

    private PlayerMovement PM;

    public PWSpells mySpells;

    public GameObject axePrefab;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PM = transform.parent.gameObject.GetComponent<PlayerMovement>();
        mySpells = GetComponent<PWSpells>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * PM.facing, transform.localScale.y, transform.localScale.z);
    }

    public float getSpeed()
    {
        return speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AxeOnWall" && mySpells.hasAxe == false)
        {
            Transform rightArm = transform.GetChild(1);
            GameObject ax = Instantiate(axePrefab, transform.position, Quaternion.identity, rightArm);
            ax.GetComponent<AxeDamage>().myself = this.gameObject;
            mySpells.hasAxe = true;
            Destroy(collision.gameObject);
        }
    }
}
