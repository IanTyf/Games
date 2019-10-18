using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{

    public GameObject timeIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void callBuff(string buffName)
    {
        if (buffName == "Time")
        {
            float duration = slowEffect();
            timeIcon.SetActive(true);
            StartCoroutine(hideBuffIcon(duration, timeIcon));
        }
        else if (buffName == "Bomb")
        {
            bombEffect();
        }
    }

    public float slowEffect()
    {
        Time.timeScale = 0.5f;
        StartCoroutine(slowBackToNormal());
        return 5f;
    }

    IEnumerator slowBackToNormal()
    {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1;
    }

    public void bombEffect()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.selfExplode();
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }

    IEnumerator hideBuffIcon(float duration, GameObject icon)
    {
        yield return new WaitForSeconds(duration);
        icon.SetActive(false);
    }
}
