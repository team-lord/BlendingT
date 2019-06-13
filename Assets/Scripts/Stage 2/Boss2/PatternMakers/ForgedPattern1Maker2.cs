﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgedPattern1Maker2 : MonoBehaviour {
    public GameObject bullet1;

    public int repetition;
    private int count;
    public float delay;
    private float time;

    private GameObject player;
    private GameObject boss;

    // Start is called before the first frame update
    void Start() {
        count = 0;
        time = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;

        if (time > delay) {
            int _random = Random.Range(0, 30);
            for (int i = 0; i < 12; i++) {
                Fire(_random + 30 * i);
            }

            time = 0;
            count++;
            CheckDestroy();
        }
    }

    void Fire(int degree) {
        Instantiate(bullet1, transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }

    void CheckDestroy() {
        if (count >= repetition) {
            boss.GetComponent<PatternB2>().PatternEnd();
            Destroy(gameObject);
        }
    }
}