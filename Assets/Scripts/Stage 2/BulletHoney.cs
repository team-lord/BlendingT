using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoney : MonoBehaviour
{
    // 속도
    public Vector3 direction;
    public float moveSpeedQ;

    private GameObject boss;

    // Start is called before the first frame update
    void Start() {
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Blanket") {
            Destroy(gameObject);
        }

        if (collider.tag == "Player") { // 이 GameObject의 태그는 EnemyBullet이 아님!
            if (!collider.GetComponent<Player>().isInvicible) {

                collider.GetComponent<Player>().health--;
                collider.GetComponent<Player>().CheckAlive();

                collider.GetComponent<Player2>().isHoneyAttached = true;

                Destroy(gameObject);
                // player의 sprite를 꿀 묻은 형태로 바꾸기
            }
        }
    }
}
