using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3Maker1 : MonoBehaviour
{
    public GameObject bullet3;
    public GameObject bullet3Follow;
    private GameObject bullet;

    public int repetition;
    private int count;
    public float delay;
    private float time;

    private GameObject player;
    private GameObject boss;    

    // Start is called before the first frame update
    void Start()
    {
        bullet = bullet3;

        count = 0;
        time = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > delay) {
            Fire(count);

            time = 0;
            count++;
            ChangeBullet();
            CheckDestroy();
        }
    }

    void Fire(int count) {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, _direction));
    }

    void ChangeBullet() {
        if(count % 2 == 0) {
            bullet = bullet3;
        } else {
            bullet = bullet3Follow;
        }
    }

    void CheckDestroy() {
        if (count >= repetition) {
            boss.GetComponent<PatternB1>().PatternEnd();
            Destroy(gameObject);
        }
    }
}
