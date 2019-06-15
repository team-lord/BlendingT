using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3Maker1 : MonoBehaviour
{
    public GameObject bullet3;
    public GameObject bullet3Follow;

    public int repetition;
    private int count;
    public float delay;
    private float time;

    private GameObject player;
    private GameObject boss;    

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        time = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > delay) {
            FireBullet();

            time = 0;
            count++;
            CheckDestroy();
        }
    }

    void FireBullet() {
        Vector3 _direction = (player.transform.position - transform.position).normalized;
        if (count % 2 == 0) {
            Instantiate(bullet3, transform.position, Quaternion.FromToRotation(Vector3.up, _direction));
        } else {
            bullet3Follow.GetComponent<Bullet3FollowMove1>().Direction(_direction);
            Instantiate(bullet3Follow, transform.position, transform.rotation);
        }
       
    }
    
    void CheckDestroy() {
        if (count >= repetition) {
            boss.GetComponent<PatternB1>().PatternEnd();
            Destroy(gameObject);
        }
    }
}
