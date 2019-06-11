using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3Maker : MonoBehaviour
{
    public GameObject bullet3;
    public GameObject bullet3Follow;

    public int repetition;
    public float delay;

    private GameObject player;
    private GameObject boss;
    private int count;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        boss = GameObject.Find("Boss");
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > delay) {
            Fire(count);

            time = 0;
            count++;
            CheckDestroy();
        }
    }

    void Fire(int count) {
        Vector3 _direction = (player.transform.position - transform.position).normalized;
        if(count % 2 == 0) { // 홀수 번째
            Instantiate(bullet3, transform.position, Quaternion.LookRotation(_direction));            
        } else { // 짝수 번째
            Instantiate(bullet3Follow, transform.position, Quaternion.LookRotation(_direction));
        }
    }

    void CheckDestroy() {
        if (count >= repetition) {
            boss.GetComponent<PatternB1>().PatternEnd();
            Destroy(gameObject);
        }
    }
}
