using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3Move2 : MonoBehaviour
{
    // 속도
    public Vector3 direction;
    public float moveSpeedQ; // slow
    public float moveRangeQ;
    private bool isMove;
    
    // 폭발
    public GameObject bulletQ; // bullet3Children
    private GameObject player;
    private GameObject boss;
    
    // Start is called before the first frame update
    void Start()
    {
        isMove = true;
        StartCoroutine(WaitMove(moveRangeQ / moveSpeedQ));

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
    }

    IEnumerator WaitMove(float time) {
        yield return new WaitForSeconds(time);
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove) {
            Move();
        }
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime, Space.Self);
    }

    void Explode() {
        for(int i=0; i<6; i++) {
            ExplodeFireBullet(60 * i);
        }
        Destroy(gameObject);
    }

    void ExplodeFireBullet(int degree) {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        Quaternion _rotation = Quaternion.LookRotation(Vector3.up, _direction);
        Quaternion _degree = Quaternion.Euler(0, 0, degree);

        Instantiate(bulletQ, transform.position, _rotation * _degree);
    }

    /*
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Blanket") {
            Destroy(gameObject);
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            Explode();
        }
    }
}
