using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int direction;

    public float fireSpeed;

    public GameObject[] letters;

    public GameObject arrows;

    public GameObject pointers;

    public AudioClip shootClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeDirection();
        fire();
    }

    public void changeDirection()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            arrows.transform.GetChild(direction).gameObject.SetActive(false);
            pointers.transform.GetChild(direction).gameObject.SetActive(false);
            direction = (direction + 1) % 4;
            arrows.transform.GetChild(direction).gameObject.SetActive(true);
            pointers.transform.GetChild(direction).gameObject.SetActive(true);
        }
    }

    public void fire()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject bullet = Instantiate(letters[0], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject bullet = Instantiate(letters[1], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject bullet = Instantiate(letters[2], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject bullet = Instantiate(letters[3], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject bullet = Instantiate(letters[4], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject bullet = Instantiate(letters[5], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject bullet = Instantiate(letters[6], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject bullet = Instantiate(letters[7], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject bullet = Instantiate(letters[8], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject bullet = Instantiate(letters[9], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject bullet = Instantiate(letters[10], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject bullet = Instantiate(letters[11], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject bullet = Instantiate(letters[12], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            GameObject bullet = Instantiate(letters[13], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject bullet = Instantiate(letters[14], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject bullet = Instantiate(letters[15], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject bullet = Instantiate(letters[16], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject bullet = Instantiate(letters[17], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject bullet = Instantiate(letters[18], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject bullet = Instantiate(letters[19], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            GameObject bullet = Instantiate(letters[20], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            GameObject bullet = Instantiate(letters[21], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject bullet = Instantiate(letters[22], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject bullet = Instantiate(letters[23], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject bullet = Instantiate(letters[24], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = Instantiate(letters[25], transform.position, Quaternion.identity);
            Bullet BL = bullet.GetComponent<Bullet>();
            BL.direction = this.direction;
            BL.speed = this.fireSpeed;
            AudioSource.PlayClipAtPoint(shootClip, transform.position + new Vector3(0, 0, 30));
        }
    }
}
