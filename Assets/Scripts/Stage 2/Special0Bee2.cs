using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special0Bee2 : MonoBehaviour
{
    public int maxHealth;
    private int health;

    private float time;
    private float time1;
    public float delay; // half-period
    private bool isPositive;

    private GameObject player;

    public GameObject honey;

    public GameObject bullet;
    
    // Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        time = 0;
        time1 = 0;

        isPositive = true;

        player = GameObject.Find("Player");

        // animator = GetComponent<Animator>();

        // 계속 날개를 움직이는(Loop) 상태가 Default State
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        time1 += Time.deltaTime;

        Move();

        if(time >= delay) {
            isPositive = !isPositive;
            time = 0;
        }
        if(time1 >= delay / 4) {
            Fire();
            time1 = 0;
        }
    }
    
    void Move() {
        if (isPositive) {
            transform.Translate(new Vector2(2 * Mathf.Cos(2 * time), 2 * Mathf.Sin(2 * time)));
        } else {
            transform.Translate(new Vector2(- 2 * Mathf.Cos(2 * time), - 2 * Mathf.Sin(2 * time)));
        }
    }

    void Fire() {
        Vector3 _direction = (player.transform.position - transform.position).normalized;
        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, _direction));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PlayerBullet") {
            health--;
            CheckAlive();
        } else if (collision.tag == "PlayerMelee") {
            // health -=2;
            CheckAlive();
        }
    }

    void CheckAlive() {
        if (health <=0) {
            Instantiate(honey, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
