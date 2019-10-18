using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeMovement : MonoBehaviour
{
    public Animator anim;

    public int direction;

    public float speed;

    public bool thrown;

    public float maxDistance;

    public Vector2 targetPos;

    public GameObject AxeOnWall;

    private AxeDamage AD;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AD = GetComponent<AxeDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thrown)
        {
            // spinning and moving forward
            if (direction == 1)
                anim.SetBool("isSpinning", true);
            else if (direction == -1)
                anim.SetBool("isSpinningLeft", true);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (transform.position.x == targetPos.x && transform.position.y == targetPos.y)
            {
                thrown = false;
            }

            if (AD.RawDamage > AD.minDamage)
            {
                AD.RawDamage -= Time.deltaTime * 150;
                Debug.Log(AD.RawDamage);
            }
            
        }
        
    }

    public void activateCollider()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        //StartCoroutine(realActivateCollider());
    }

    IEnumerator realActivateCollider()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.tag == "Wall" && thrown)
        {
            GameObject axeonwall = Instantiate(AxeOnWall, transform.position, Quaternion.identity);
            axeonwall.transform.SetParent(collision.transform.parent, true);
            axeonwall.transform.localScale = new Vector3(axeonwall.transform.localScale.x * direction, axeonwall.transform.localScale.y, axeonwall.transform.localScale.z);
            Destroy(this.gameObject);
        }
    }
}
