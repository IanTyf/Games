using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public SpriteRenderer SR;

    public Animator shakeAnim;
    public GameObject Background;

    public AudioClip hitsound;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(h, v, 0);
        transform.position += movement.normalized * speed * Time.deltaTime;
        if (transform.position.x <= -9) transform.position = new Vector3(-9, transform.position.y, transform.position.z);
        if (transform.position.x >= 9) transform.position = new Vector3(9, transform.position.y, transform.position.z);
        if (transform.position.y <= -5.1) transform.position = new Vector3(transform.position.x, -5.1f, transform.position.z);
        if (transform.position.y >= 5.1) transform.position = new Vector3(transform.position.x, 5.1f, transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PB")
        {
            AudioSource.PlayClipAtPoint(hitsound, transform.position);

            Color pbColor = collision.GetComponent<SpriteRenderer>().color;
            float thisPortion = transform.localScale.x / (transform.localScale.x + collision.transform.localScale.x);
            float theirPortion = collision.transform.localScale.x / (transform.localScale.x + collision.transform.localScale.x);
            float r = SR.color.r * thisPortion + pbColor.r * theirPortion;
            float g = SR.color.g * thisPortion + pbColor.g * theirPortion;
            float b = SR.color.b * thisPortion + pbColor.b * theirPortion;
            SR.color = new Color(r, g, b);
            shakeAnim.SetTrigger("Shake");
            Background.GetComponent<BG>().FlashColor(SR.color);
            collision.GetComponent<paintballMovement>().Explode();
        }
    }
}
