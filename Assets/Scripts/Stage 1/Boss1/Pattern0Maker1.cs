using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern0Maker1 : MonoBehaviour
{
    public GameObject[] bullet0s = new GameObject[4];
    private GameObject bullet;

    public int repetition;
    public float delay;
    private float time;

    private GameObject player;
    private GameObject boss;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > delay) {
            bullet = bullet0s[Random.Range(0, bullet0s.Length)];
            for(int i=0; i<5; i++) {
                Fire(bullet, -40 + 20 * i);
            }

            time = 0;
            count++;
            CheckDestroy();
        }
    }

    void Fire(GameObject bullet, float degree) {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        Quaternion _rotation = Quaternion.Euler(0, 0, degree);
        Vector3 _newDirection = _rotation * _direction;

        Instantiate(bullet, transform.position, Quaternion.LookRotation(_newDirection));
    }

    void CheckDestroy() {
        if (count >= repetition) {
            boss.GetComponent<PatternB1>().PatternEnd();
            Destroy(gameObject);
        }
    }

}
