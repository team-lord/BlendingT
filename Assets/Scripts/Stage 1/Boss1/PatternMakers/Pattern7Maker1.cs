using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern7Maker1 : MonoBehaviour {
    public GameObject[] waveMakers = new GameObject[4];

    private GameObject player;
    private GameObject boss;

    private float time;
    public float life;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        time = 0;

        transform.position = player.transform.position;
        
        // 7번 패턴임을 알려주는 효과음
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        if(time > life) {
            CheckAlive();
        }
    }

    void CheckAlive() {
        boss.GetComponent<PatternB1>().PatternEnd();
        Destroy(gameObject);
    }
}