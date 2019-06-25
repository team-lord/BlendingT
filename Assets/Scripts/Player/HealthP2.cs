using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthP2 : MonoBehaviour {

    // 체력
    public int maxHealth;
    private int health;

    // 피격시 무적 딜레이
    public float invincibleTime;
    private bool isInvincible;
    public GameObject shield;

    public Image heart;
    
    // Start is called before the first frame update
    void Start() {
        health = maxHealth;

        isInvincible = false;
    }

    // Update is called once per frame
    void Update() {

    }

    public void Hit() {
        if (!isInvincible) {
            StartCoroutine(IsInvincible());

            health--;
            CheckAlive();

            Instantiate(shield, transform.position, Quaternion.identity);
           // ChangeHeart();
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

    public bool GetIsInvincible() {
        return isInvincible;
    }
}
