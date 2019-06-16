﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardTableHole1 : MonoBehaviour
{
    public GameObject puzzleBall;

    public Vector3 locationOffset;

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isReady) {
            if (collision.tag == "PuzzleBall") {
                isReady = false;
                Destroy(collision);
                Instantiate(puzzleBall, transform.position + locationOffset, Quaternion.identity);
            }
        }
    }
}
