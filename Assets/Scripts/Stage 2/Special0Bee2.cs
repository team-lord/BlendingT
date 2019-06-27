using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special0Bee2 : MonoBehaviour
{
    public int maxHealth;
    private int health;

    private float rotateTime;
    private float fireTime;
    public float rotateDelay;
    public float fireDelay;

    public float moveSpeed;

    private GameObject player;

    public GameObject honey;

    public GameObject bullet;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rotateTime = 0;
        fireTime = 0;
        player = GameObject.Find("Player");

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        rotateTime += Time.deltaTime;
        fireTime += Time.deltaTime;

        Move();

        if (rotateTime >= rotateDelay) {
            Rotate();
            rotateTime = 0;
        }
        if (fireTime >= fireDelay) {
            Fire();
            fireTime = 0;
        }


    }
    
    void Move() {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
    }

    void Rotate() {
        int _degree = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, _degree));
    }

    void Fire() {
        Vector3 _direction = (player.transform.position - transform.position).normalized;
        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, _direction));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "NearbyWall") {
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 180));
        }
        if (collision.tag == "PlayerBullet") {
            Destroy(collision.gameObject);
            health--;
            CheckAlive();
        } else if (collision.tag == "PlayerMelee") {
            health -= 2;
            CheckAlive();
        }

    }


    void CheckAlive() {
        if (health <= 0) {
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy() {
        fireTime = -1;
        Vector3 _position = transform.position;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        Instantiate(honey, _position, Quaternion.identity);
        Destroy(gameObject);
    }
}
