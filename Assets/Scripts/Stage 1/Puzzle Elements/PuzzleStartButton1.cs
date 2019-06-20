﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStartButton1 : MonoBehaviour
{
    private GameObject puzzleBall;

    private bool isReady;

    private GameObject player;
    private GameObject boss;

    public Sprite buttonOn;
    private Sprite buttonOff;

    // Start is called before the first frame update
    void Start()
    {
        puzzleBall = GameObject.Find("PuzzleBall");

        isReady = true;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        buttonOff = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isReady) {
            if (collision.tag == "PlayerBullet") { //if (collision.tag == "PlayerMelee") {
                isReady = false;
                GetComponent<SpriteRenderer>().sprite = buttonOn;
                puzzleBall.GetComponent<Rigidbody2D>().AddForce(200 * Vector2.right);
            }
        }        
    }

    public void Initialize() {
        isReady = true;
        GetComponent<SpriteRenderer>().sprite = buttonOff;
    }
}
