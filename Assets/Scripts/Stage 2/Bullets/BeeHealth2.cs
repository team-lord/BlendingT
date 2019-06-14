﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHealth2 : MonoBehaviour
{
    public bool isBeeA;

    public int maxHealth;
    private int health;

    public float wakeDelay;
    private float time;

    private bool isLethal;
    
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLethal) {
            time += Time.deltaTime;
            if(time > wakeDelay) {
                if (isBeeA) {
                    GetComponent<BeeA2>().IsLethal(false);
                } else {
                    GetComponent<BeeB2>().IsLethal(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isLethal) {
            if(collision.tag == "PlayerMelee") {
                // TODO - 벌이 맵 바깥으로 도망가는 애니메이션
                Destroy(collision);
                // Destroy(gameObject);
            }
        } else {
            if(collision.tag == "PlayerBullet") {
                health--;
                Destroy(collision);

                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                // health -= 2;
                Destroy(collision);
                CheckAlive();
            }
        }
    }

    void CheckAlive() {
        if(health <= 0) {
            isLethal = true;
            if (isBeeA) {
                GetComponent<BeeA2>().IsLethal(true);
            } else {
                GetComponent<BeeB2>().IsLethal(true);
            }
            health = maxHealth / 2;
        }
    }
}