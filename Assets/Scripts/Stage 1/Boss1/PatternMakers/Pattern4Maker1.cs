using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern4Maker1 : MonoBehaviour
{
    public GameObject bullet4;

    public int repetition;
    public float delay;
    private int count;

    private GameObject player;
    private GameObject boss;    

    private float time;

    public float patternTime; // 구르기 언제까지 켜놓을까?

    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        player.GetComponent<MoveTumbleP1>().Pattern4Start(patternTime);

        time = 0;
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        if (time > delay) {
            for(int i=0; i<36; i++) {
                Fire(10 * i);
            }            

            time = 0;
            count++;
            CheckDestroy();
        }
    }

    void Fire(int degree) {
        Instantiate(bullet4, transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }

    void CheckDestroy() {
        if (count >= repetition) {
            boss.GetComponent<PatternB1>().PatternEnd();
            Destroy(gameObject);
        }
    }
}
