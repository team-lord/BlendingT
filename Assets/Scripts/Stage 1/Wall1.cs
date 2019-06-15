﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall1 : MonoBehaviour
{
    private GameObject audienceManager;
    private GameObject player;

    private bool isReady;
    public float pushDelay;

    public Vector3 normalVector;

    // Start is called before the first frame update
    void Start()
    {
        audienceManager = GameObject.Find("AudienceManager");
        player = GameObject.Find("Player");

        isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (isReady) {
            if (collision.tag == "Player") {
                StartCoroutine(IsReady());
                audienceManager.GetComponent<AudienceManager>().WallHit();
                player.transform.Translate(normalVector); // 밀쳐내기
            }
        }        
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(pushDelay);
        isReady = true;
    }
}