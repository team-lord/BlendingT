using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // 체력
    public int maxHealthQ;
    public int health;
    public bool isAlive;

    // 이동
    public float moveSpeedQ;

    public int h;
    public int v;

    // Blanket
    public GameObject blanketQ;
    public bool canUseBlanket;

    // 공격
    public Vector3 direction;
    public GameObject bulletQ;
    public float fireDelayQ;
    private GameObject cursor;
    public bool canFire;

    // 구르기 -- 아직 연계 하나도 안했음
    public bool canTumble;
    public float tumbleTimeQ;
    public float tumbleSpeedQ;
    public float tumbleDelayQ;
    public bool isTumbling;
    public bool tumblePulse; // 보내야 할 곳: bullet5move, audienceManager 꼭 잊지 말자. 딱 1프레임만 보내고 꺼야함.

    // 근접 공격

    // ...

    // Start is called before the first frame update
    void Start() {
        health = maxHealthQ;
        isAlive = true;

        h = 0;
        v = 0;

        canUseBlanket = false; // Scene Changer가 바꿀 것

        cursor = GameObject.Find("Cursor");
        canFire = true;

        canTumble = false; // Scene Changer가 바꿀 것
    }

    private void FixedUpdate() {
        FixRotate();
    }

    // Update is called once per frame
    void Update() {

        if (isAlive) {
            Move();
            if (canFire) {
                if (Input.GetMouseButton(0)) {
                    Fire();
                }
            }
            if (canUseBlanket) {
                if (Input.GetMouseButton(1)) {
                    FireBlanket();
                }
            }
            if (canTumble) {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    Tumble();
                }
            }
        } else {
            Destroy(gameObject);
        }
    }

    void FixRotate() {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    void Move() {
        // float h = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") > 0) {
            h = 1;
        } else if (Input.GetAxis("Horizontal") < 0) {
            h = -1;
        } else {
            h = 0;
        }
        transform.Translate(h * Vector3.right * moveSpeedQ * Time.deltaTime, Space.World);

        if (Input.GetAxis("Vertical") > 0) {
            v = 1;
        } else if (Input.GetAxis("Vertical") < 0) {
            v = -1;
        } else {
            v = 0;
        }
        transform.Translate(v * Vector3.up * moveSpeedQ * Time.deltaTime, Space.World);
    }

    void Fire() {
        StartCoroutine(FireCooltime(fireDelayQ));
        direction = (cursor.transform.position - transform.position).normalized;
        Instantiate(bulletQ, transform.position, Quaternion.FromToRotation(Vector3.up, direction));
    }

    IEnumerator FireCooltime(float time) {
        canFire = false;
        yield return new WaitForSeconds(time);
        canFire = true;
    }
    
    void FireBlanket() {
        canUseBlanket = false;
        Instantiate(blanketQ, transform.position, transform.rotation);
    }

    void Tumble() {
        // TODO
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "EnemyBullet" && !isTumbling) { // 구르고 있을 때는 무적 (collider를 끌까?)
            Destroy(collider);
            health--;
            CheckAlive();
        }
    }

    void CheckAlive() {
        if (health <= 0) {
            isAlive = false;
            // TODO
        }
    }
}
