using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Move2 : MonoBehaviour {

    // 속도
    public float moveSpeed;
    public float moveRange;
    private bool isMove;

    // 폭발
    public GameObject bullet; // bullet3Children
    private GameObject player;
    private GameObject boss;

    private float time;
    private float moveTime;

    // Start is called before the first frame update
    void Start() {
        isMove = true;
        moveTime = moveRange / moveSpeed;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        time = 0;
    }

    // Update is called once per frame
    void Update() {
        if (isMove) {
            time += Time.deltaTime;
            Move();
            if(time > moveTime) {
                isMove = false;
            }
        }
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
    }

    void Explode() {
        for (int i = 0; i < 6; i++) {
            ExplodeFireBullet(60 * i);
        }
        Destroy(gameObject);
    }

    void ExplodeFireBullet(int degree) {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        Quaternion _rotation = Quaternion.FromToRotation(Vector3.up, _direction);
        Quaternion _degree = Quaternion.Euler(0, 0, degree);

        Instantiate(bullet, transform.position, _rotation * _degree);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Debug.Log(collision.tag);
            Explode();
        }
    }
}
