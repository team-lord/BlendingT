using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthP1 : MonoBehaviour {
    
    // 체력
    public int maxHealth;
    private int health;

    // 피격시 무적 딜레이
    public float invincibleTime;
    private bool isInvincible;

    public GameObject shield;

    private GameObject audienceManager;

    public Image heart;

    // Start is called before the first frame update
    void Start() {
        health = maxHealth;

        isInvincible = false;

        audienceManager = GameObject.Find("AudienceManager");
    }

    // Update is called once per frame
    void Update() {

    }
    
    public void Hit() {
        if (!isInvincible) {
            health--;
            CheckAlive();

            Instantiate(shield, transform.position, Quaternion.identity);
            audienceManager.GetComponent<AudienceManager1>().PlayerHit();
            ChangeHeart();


            StartCoroutine(IsInvincible());
        }
    }

    void ChangeHeart() {
        // TODO - UI의 하트와 연결
        heart.GetComponent<Heart>().ChangeImage();
    }

    void CheckAlive() {
        if (health <= 0) {
            SceneManager.LoadScene("Main Menu");
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

    public void IsInvincible(bool _bool) {
        isInvincible = _bool;
    }
}
