﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1Maker1 : MonoBehaviour {

    public GameObject bullet1;

    public int repetition;
    public float delay;
    private float time;

    private GameObject boss;
    private int count;

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
            for(int i=0; i<18; i++) {
                Fire(20 * i);
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
            boss.GetComponent<PatternB1>().PatternEnd();
            Destroy(gameObject);
        }
    }
}