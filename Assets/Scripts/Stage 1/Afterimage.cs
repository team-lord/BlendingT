﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afterimage : MonoBehaviour
{
    public float moveSpeedQ;
    public float lifeQ;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeQ);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Blanket") {
            Destroy(gameObject);
        }
    }
}