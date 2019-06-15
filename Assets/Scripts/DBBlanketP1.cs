﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBBlanketP1 : MonoBehaviour {
    private GameObject boss;

    // Start is called before the first frame update
    void Start() {
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Blanket") {
            boss.GetComponent<PatternB1>().ForceStart();
            Destroy(gameObject);
        }
    }
}