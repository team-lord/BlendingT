using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeeA2 : MonoBehaviour
{
    public int maxHealth;
    private int health;
    
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();        
    }

    void Rotate() {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        float _z = Vector3.Cross(transform.up, _direction).z;
        transform.Translate(Vector3.right * _z * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PlayerBullet") {
            health--;
            CheckAlive();
        } else if (collision.tag == "PlayerMelee") {
            // health -= 2;
            CheckAlive();
        }
    }

    void CheckAlive() {
        if(health <= 0) {
            // 터지는 애니메이션
            Destroy(gameObject);
        }
    }
}
