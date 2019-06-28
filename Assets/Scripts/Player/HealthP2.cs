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

    private bool isHoneyInvincible;

    // Start is called before the first frame update
    void Start() {
        health = maxHealth;

        isInvincible = false;
        isHoneyInvincible = false;
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
            ChangeHeart();
        }
    }

    public void HoneyHit() {
        StartCoroutine(IsHoneyInvincible());
    }

    void ChangeHeart() {      
        heart.GetComponent<Heart>().ChangeImage();

    }

    void CheckAlive() {
        if (health <= 0) {
            SceneManager.LoadScene("Game Over");
        }
    }

    IEnumerator IsInvincible() {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

    IEnumerator IsHoneyInvincible() {
        isHoneyInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isHoneyInvincible = false;
    }

    public void IsInvincible(bool _bool) {
        isInvincible = _bool;
    }

    public bool GetIsInvincible() {       
        return isInvincible;
    }

    public void IsHoneyInvincible(bool _bool) {
        isHoneyInvincible = _bool;
    }

    public bool GetIsHoneyInvincible() {
        Debug.Log("Get");
        return isHoneyInvincible;
    }

}
