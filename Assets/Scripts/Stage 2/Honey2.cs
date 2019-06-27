﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honey2 : MonoBehaviour
{
    private GameObject boss;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            if (!player.GetComponent<HealthP2>().GetIsHoneyInvincible()) {
                player.GetComponent<HealthP2>().HoneyHit();
                boss.GetComponent<FireBeeAB2>().Fire();
            }
            Destroy(gameObject);
            // 플레이어 꿀 맞은 스프라이트
        }
    }
}
