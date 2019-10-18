using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public float speed;

    public int direction;

    public Info myInfo;

    public GameObject particles;

    public AudioClip explode;



    // Start is called before the first frame update
    void Start()
    {
        myInfo = GetComponent<Info>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        switch (direction)
        {
            case 2:
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                break;
            case 0:
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                break;
            case 3:
                transform.Translate(Vector2.up * speed * Time.deltaTime);
                break;
            case 1:
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Info info = other.GetComponent<Info>();
            // sucessfull hit
            if (myInfo.letters.Length == 0)
            {
                if (info.letter == myInfo.letter)
                {
                    ScoreBoard SB = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>();
                    SB.incrementScore();
                    Destroy(other.gameObject);
                    Instantiate(particles, transform.position, Quaternion.identity);
                    AudioSource.PlayClipAtPoint(explode, transform.position);
                    Destroy(this.gameObject);
                }
                else
                {
                    GameOver GM = GameObject.Find("GameOverMenu").GetComponent<GameOver>();
                    GM.showMenu();

                }
            }
            else
            {
                if (info.letter == myInfo.letters[myInfo.lettersDone])
                {
                    transform.GetChild(myInfo.lettersDone).gameObject.SetActive(true);
                    myInfo.lettersDone++;
                    Destroy(other.gameObject);
                    if (myInfo.lettersDone == myInfo.letters.Length)
                    {
                        Buffs bfs = GameObject.Find("BuffController").GetComponent<Buffs>();
                        bfs.callBuff(myInfo.letter);
                        AudioSource.PlayClipAtPoint(explode, transform.position);
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    GameOver GM = GameObject.Find("GameOverMenu").GetComponent<GameOver>();
                    GM.showMenu();

                }
            }
        }
        else if (other.tag == "Player")
        {
            GameOver GM = GameObject.Find("GameOverMenu").GetComponent<GameOver>();
            GM.showMenu();
        }
    }

    public void selfExplode()
    {
        if (myInfo.letters.Length == 0)
        {
            ScoreBoard SB = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>();
            SB.incrementScore();
            Instantiate(particles, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explode, transform.position);
            Destroy(this.gameObject);
        }
        else
        {
            AudioSource.PlayClipAtPoint(explode, transform.position);
            Destroy(this.gameObject);
        }
    }
}
