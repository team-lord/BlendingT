using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3Maker2 : MonoBehaviour
{
    public GameObject[] bullet3s = new GameObject[2]; // bullet3Honey, bullet3Bee
    private int bullet3Number;
    private GameObject bullet3;

    public int repetition;
    private int count;
    public float delay;
    private float time;

    public int angle;

    private GameObject player;
    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        bullet3Number = 0;
        bullet3 = bullet3s[bullet3Number];

        count = 0;
        time = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > delay) {
            for(int i=0; i<6; i++) {
                Fire((i - 2.5f) * angle);
                ChangeBullet();
            }

            count++;
            time = 0;
            CheckDestroy();
        }
    }

    void Fire(float degree) {
        Vector3 _direction = (player.transform.position - transform.position).normalized;
        Quaternion _rotation = Quaternion.FromToRotation(Vector3.up, _direction);
        Quaternion _degree = Quaternion.Euler(new Vector3(0, 0, degree));

        Instantiate(bullet3, transform.position, _rotation * _degree);
    }

    void ChangeBullet() {
        if (bullet3Number == 0) {
            bullet3Number = 1;
        } else {
            bullet3Number = 0;
        }

        bullet3 = bullet3s[bullet3Number];
    }

    void CheckDestroy() {
        if (count >= repetition) {
            boss.GetComponent<PatternB2>().PatternEnd();
            Destroy(gameObject);
        }
    }
}
