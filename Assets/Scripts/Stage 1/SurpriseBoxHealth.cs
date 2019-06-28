using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBoxHealth : MonoBehaviour
{
    public int maxHealth;
    private int health;

    public GameObject shield;
    public float shieldDelay;
    private bool isVulnerable;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        isVulnerable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Blanket")
        {
            Destroy(gameObject);
        }

        if (isVulnerable) {
            if (collision.tag == "PlayerBullet") {
                health--;
                Destroy(collision.gameObject);

                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                health -= 2;

                CheckAlive();
            }
        }

    }

    void CheckAlive() {
        if (health <= 0) {
            Explode();
            Destroy(gameObject);
        } else {
            Instantiate(shield, transform.position, transform.rotation);
        }
        StartCoroutine(IsVulnerable());
    }

    IEnumerator IsVulnerable() {
        isVulnerable = false;
        yield return new WaitForSeconds(shieldDelay);
        isVulnerable = true;        
    }

    void Explode() {
        for(int i=0; i<6; i++) {
            Fire(30 + 60 * i);
        }
    }

    void Fire(int degree) {
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }
}
