using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthP : MonoBehaviour {
    
    // 체력
    public int maxHealth;
    private int health;

    // 피격시 무적 딜레이
    public float invincibleTime;
    private bool isInvincible;

    // Start is called before the first frame update
    void Start() {
        health = maxHealth;

        isInvincible = false;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "EnemyBullet" || collision.tag == "Bullet41" ) { // 계속 추가해 나가세요
            Destroy(collision);

            if (!isInvincible) {
                health--;
                CheckAlive();

                StartCoroutine(IsInvincible());
            }
        }
    }

    void CheckAlive() {
        if (health <= 0) {
            // 쓰러지는 애니메이션
            Destroy(gameObject);
            // 씬 처리
        }
    }

    IEnumerator IsInvincible() {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}
