using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3Honey2 : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (!player.GetComponent<HealthP2>().GetIsHoneyInvincible()) {
                player.GetComponent<HealthP2>().HoneyHit();
                boss.GetComponent<FireBeeAB2>().Fire();
            }

            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy() {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
