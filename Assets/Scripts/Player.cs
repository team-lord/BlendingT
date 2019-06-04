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

        canUseBlanket = false; // Scene Changer가 바꿀 것

        cursor = GameObject.Find("Cursor");
        canFire = true;
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
        } else {
            Destroy(gameObject);
        }
    }

    void FixRotate() {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    void Move() {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Translate(h * Vector3.right * moveSpeedQ, Space.World);
        float v = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(v * Vector3.up * moveSpeedQ, Space.World);
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

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "EnemyBullet") {
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
