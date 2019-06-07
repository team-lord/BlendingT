using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeeA : MonoBehaviour
{
    public float moveSpeedQ;
    public int maxHealthQ;
    private int health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealthQ;
    }

    // Update is called once per frame
    void Update()
    {
        MoveFollow();
    }

    void MoveFollow() {
        // TODO
        // 유도 기능 
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "PlayerBullet") {
            health--;
            CheckAlive();
        }
        if(collider.tag == "PlayerMelee") {
            // health -= 2;
            CheckAlive();
        }
    }

    void CheckAlive() {
        if(health <= 0) {
            Destroy(gameObject);
        }
    }
}
